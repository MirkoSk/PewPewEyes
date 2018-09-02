using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

/// <summary>
/// 
/// </summary>
public class ShootLaserFromAnimator : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] StateMachine stateMachine;
    [SerializeField] GameObject shootState;
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
	public void ShootLaser()
    {
        stateMachine.ChangeState(shootState);
    }
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}