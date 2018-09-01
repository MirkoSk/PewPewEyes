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
    [SerializeField] EnemyDeath death;

    // Private
    int currentHP;
    float timer;
    bool wait = true;
    bool logicBlocked;
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
        if (!logicBlocked)
        {
            if (agent.isOnNavMesh && Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) >= 10f)
            {
                agent.SetDestination(GameManager.Instance.Player.transform.position);
            }
            else if (agent.isOnNavMesh)
            {
                agent.SetDestination(transform.position);
            }
            if (GameManager.Instance != null)
                transform.LookAt(GameManager.Instance.Player.transform);

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
    #endregion



    #region Private Functions
    private void CheckDeath()
    {
        if (currentHP <= 0)
        {
            death.ani.SetBool("death", true);
            logicBlocked = true;
            Invoke("KillObj", 2.5f);
        }
    }
    private void KillObj()
    {
        Destroy(gameObject);
    }
    #endregion



    #region Coroutines
    
    #endregion
}