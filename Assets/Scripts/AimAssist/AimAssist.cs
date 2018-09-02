using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class AimAssist : MonoBehaviour
{

    #region Variable Declarations
    // Serialized Fields
    [Space]
    [SerializeField] float lineLength = 10f;
    [SerializeField] float lineDuration = 2f;

    // Private

    #endregion



    #region Public Properties
    
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		
	}

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponentInParent<Rigidbody>();

        if (rb != null)
        {
            if (rb.CompareTag(Constants.TAG_LASER))
            {
                rb.GetComponent<Laser>().UpdateAimAssist(lineLength, lineDuration);
            }
            else if (rb.CompareTag(Constants.TAG_ENEMY))
            {
                rb.GetComponent<Enemy>().UpdateAimAssist(lineLength, lineDuration);
            }
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