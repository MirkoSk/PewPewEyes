using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Laser : MonoBehaviour 
{

    #region Variable Declarations
    public Enemy owner;
    
    // Serialized Fields

	// Private
	
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Constants.TAG_ENEMY))
        {

        }
    }
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}