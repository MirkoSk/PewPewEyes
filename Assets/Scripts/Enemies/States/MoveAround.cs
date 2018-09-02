using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.AI;

/// <summary>
/// 
/// </summary>
public class MoveAround : State 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject nextState;

    // Private
    float timer;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		
	}

    private void OnEnable()
    {
        timer = 0f;
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        // Look at player
        if (GameManager.Instance != null) transform.LookAt(GameManager.Instance.Player.transform);

        // set destination
        if (enemy.Agent.isOnNavMesh && Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) >= 10f)
        {
            enemy.Agent.SetDestination(GameManager.Instance.Player.transform.position);
        }
        else if (enemy.Agent.isOnNavMesh)
        {
            enemy.Agent.SetDestination(transform.position);
            enemy.transform.LookAt(GameManager.Instance.Player.transform);
        }

        // check and increase timer
        if (timer >= enemy.EnemyType.moveStateDuration)
        {
            ChangeState(nextState);
        }
        timer += Time.deltaTime;

    }
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}