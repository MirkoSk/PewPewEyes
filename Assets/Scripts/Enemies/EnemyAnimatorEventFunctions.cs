using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

/// <summary>
/// 
/// </summary>
public class EnemyAnimatorEventFunctions : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] StateMachine stateMachine;
    [SerializeField] GameObject shootState;
    [SerializeField] List<Transform> shells;
    [SerializeField] GameObject eye;
    [SerializeField] float initialVelocity;
    [SerializeField] float dissolveTime = 1f;
    [SerializeField] bool eventOnDissolve;
    [ConditionalHide("eventOnDissolve", false, false)] [SerializeField] GameEvent dissolveEvent;
    // Private

    #endregion



    #region Public Properties
    public float DissolveTime { get { return dissolveTime; } }
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

    public void Explode()
    {
        GetComponent<Animator>().enabled = false;

        eye.SetActive(false);

        shells.ForEach((Transform t) =>
        {
            Rigidbody rb = t.gameObject.AddComponent<Rigidbody>();
            t.gameObject.GetComponent<MeshCollider>().enabled = true;
            rb.drag = 0f;
            rb.mass = 5f;
            rb.velocity = transform.position + t.position * initialVelocity;

            Material mat = t.GetComponent<Renderer>().material;
            LeanTween.value(0f, 1f, dissolveTime).setEaseInOutQuad().setOnUpdate((float value) =>
            {
                mat.SetFloat("_Dissolve", value);
            }).setOnComplete(()=>
            {
                if (eventOnDissolve)
                {
                    dissolveEvent.Raise();
                }
            });

        });
    }
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}