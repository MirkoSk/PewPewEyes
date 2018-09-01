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

    [Header("References")]
    [SerializeField] LayerMask shieldLayer;
    [SerializeField] GameObject aimingLinePrefab;

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
        Rigidbody rb = other.GetComponentInParent<Rigidbody>();

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
        Physics.Raycast(ray, out hitInfo, 20f, shieldLayer);

        if (hitInfo.point != Vector3.zero) Debug.DrawLine(ray.origin, hitInfo.point, Color.green, lineLength);
        else Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);

        Vector3 reflection = Vector3.Reflect(ray.direction, hitInfo.normal);

        LineRenderer aimingLine = GameObject.Instantiate(aimingLinePrefab, hitInfo.point, Quaternion.identity, transform).GetComponent<LineRenderer>();
        aimingLine.positionCount = 2;
        aimingLine.SetPosition(0, hitInfo.point);
        aimingLine.SetPosition(1, hitInfo.point + reflection * lineLength);
    }
    #endregion



    #region Coroutines

    #endregion
}