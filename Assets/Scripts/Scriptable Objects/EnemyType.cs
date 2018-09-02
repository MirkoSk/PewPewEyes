using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy Type")]
public class EnemyType : ScriptableObject 
{

    #region Variable Declarations
    // Public
    public int hp;
    public float moveStateDuration = 3f;
    public GameObject laserBeamPrefab;
    public int scoreOnDeath = 10;

    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Start () 
	{
		
	}
	#endregion
	
	
	
	#region Public Functions
	
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}