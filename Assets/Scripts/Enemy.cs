using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour 
{
	
	#region Variable Declarations
	// Serialized Fields
	[SerializeField] GameObject LaserBeamPrefab;
    [SerializeField] float shootInterval = 1f;
    [SerializeField] float offset;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] EnemyType enemyType;

    // Private
    int currentHP;
    float timer;
    bool wait = true;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        currentHP = enemyType.hp;
	}

    private void Update()
    {
        transform.LookAt(GameManager.Instance.player.transform);

        if (!wait && timer >= shootInterval)
        {
            ShootLaser();
            timer = 0f;
        }
        else if (wait && timer >= offset)
        {
            wait = false;
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
    #endregion



    #region Public Functions
    public void ShootLaser()
    {
        GameObject laser = GameObject.Instantiate(LaserBeamPrefab, transform.position + transform.forward + Vector3.up * 0.5f, Quaternion.identity);
        laser.GetComponent<Rigidbody>().velocity = transform.forward * laserSpeed;
        laser.GetComponent<Laser>().Owner = this;
    }

    public void DealDamage(int amount)
    {
        currentHP -= amount;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}