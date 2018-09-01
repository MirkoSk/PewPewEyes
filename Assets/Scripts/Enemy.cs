using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 
/// </summary>

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
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
    NavMeshAgent agent;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        agent = GetComponent<NavMeshAgent>();

        currentHP = enemyType.hp;
	}

    private void Update()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) >= 7f)
        {
            agent.SetDestination(GameManager.Instance.player.transform.position);
        }

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