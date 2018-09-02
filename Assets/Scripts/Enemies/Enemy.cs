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
    [Space]
    [SerializeField] EnemyType enemyType;
    [SerializeField] Score score;

    [Header("References")]
    [SerializeField] EnemyDeath death;
    [SerializeField] Animator animator;

    // Private
    int currentHP;

    // Public
    [HideInInspector] public SpawnManager spawnManager;
    NavMeshAgent agent;
	#endregion
	
	
	
	#region Public Properties
	public EnemyType EnemyType { get { return enemyType; } }
    public NavMeshAgent Agent { get { return agent; } }
    public Animator Animator { get { return animator; } }
    #endregion



    #region Unity Event Functions
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start () 
	{
        currentHP = enemyType.hp;
	}

    private void Update()
    {

    }
    #endregion



    #region Public Functions
    public void TakeDamage(int amount)
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
            score.IncreaseScore(enemyType.scoreOnDeath);
            death.ani.SetBool("death", true);
            Invoke("KillObj", 2.5f);
        }
    }
    private void KillObj()
    {
        spawnManager.UnregisterEnemy(gameObject);
        Destroy(gameObject);
    }
    #endregion



    #region Coroutines
    
    #endregion
}