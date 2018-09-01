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
    [SerializeField] LayerMask layerMask;
    
	// Private
	
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.FindComponentInParents<Rigidbody>();

        if (rb != null && rb.CompareTag(Constants.TAG_LASER))
        {
            CreateAimAssist(rb.transform);
        }
    }
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions
    void CreateAimAssist(Transform laser)
    {
        Ray ray = new Ray(laser.position, laser.GetComponent<Rigidbody>().velocity.normalized);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, 20f, layerMask);

        //Debug.Log(hitInfo);
    }
    #endregion



    #region Coroutines

    #endregion
}