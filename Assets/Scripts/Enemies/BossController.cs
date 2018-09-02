using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class BossController : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] float activationDelay = 0.18f;
    [SerializeField] float flightHeight = 10f;
    [SerializeField] float smoothTime = 0.1f;
    [SerializeField] Animator animator;
    [SerializeField] GameEvent gameEvent;

    // Private
    Vector3 currentVelocity;
    Vector3 targetPosition;
    bool active;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        targetPosition = transform.position + Vector3.up * flightHeight;

    }

    private void Update()
    {
        if (active)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        }
    }
    #endregion



    #region Public Functions
    public void Hit()
    {
        animator.SetTrigger("hit");
    }

    public void Activate()
    {
        animator.SetTrigger("hit");
        Invoke("ActivateDelayed", activationDelay);
    }

    public void Death()
    {

    }
	#endregion
	
	
	
	#region Private Functions
    void ActivateDelayed()
    {
        animator.SetTrigger("activate");
        active = true;
    }
	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}