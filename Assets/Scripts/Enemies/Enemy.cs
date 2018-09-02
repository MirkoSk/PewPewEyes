using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pixelplacement;

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
    [SerializeField] LaserType laserType;
    [SerializeField] Score score;

    [Header("References")]
    [SerializeField] Animator animator;
    [SerializeField] GameObject deathState;

    // Private
    int currentHP;

    // Public
    [HideInInspector] public SpawnManager spawnManager;
    NavMeshAgent agent;
	#endregion
	
	
	
	#region Public Properties
	public EnemyType EnemyType { get { return enemyType; } }
	public LaserType LaserType { get { return laserType; } }
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
            animator.SetBool("death", true);
            agent.SetDestination(transform.position);
            transform.Find("States").GetComponent<StateMachine>().ChangeState(deathState);
            score.IncreaseScore(enemyType.scoreOnDeath);
            Invoke("KillObj", animator.GetComponent<EnemyAnimatorEventFunctions>().DissolveTime);
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