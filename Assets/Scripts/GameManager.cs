using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameManager : MonoBehaviour
{

    #region Variable Declarations
    public static GameManager Instance;

    // Serialized Fields

    // Private

    // Public
    [HideInInspector] public GameObject player;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Awake () 
	{
        // Singleton
        {
            //Check if instance already exists
            if (Instance == null)

                //if not, set instance to this
                Instance = this;

            //If instance already exists and it's not this:
            else if (Instance != this)
            {

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);
            }
        }

        player = GameObject.FindGameObjectWithTag(Constants.TAG_PLAYER);
	}
	#endregion
	
	
	
	#region Public Functions
	
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}