using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class EnemyDeath : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    public Animator animator;
    [SerializeField] List<Transform> shells;
    [SerializeField] float initialVelocity;
    [SerializeField] float dissolveTime = 1f;
    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("death", true);
        }
    }
    #endregion



    #region Public Functions
    public void DestroyEnemy()
    {
        animator.enabled = false;


        shells.ForEach((Transform t) =>
        {
            //t.SetParent(null, true);
            Rigidbody rb = t.gameObject.AddComponent<Rigidbody>();
            t.gameObject.GetComponent<MeshCollider>().enabled = true;
            rb.drag = 0f;
            rb.mass = 5f;
            rb.velocity = transform.position + t.position * initialVelocity;

            Material mat = t.GetComponent<Renderer>().material;
            LeanTween.value(0f, 1f, dissolveTime).setEaseInOutQuad().setOnUpdate((float value) =>
            {
                mat.SetFloat("_Dissolve", value);
            });
            
        });
    }
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}