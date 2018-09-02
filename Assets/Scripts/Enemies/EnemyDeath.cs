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
    public Animator ani;
    [SerializeField] List<Transform> shells;
    [SerializeField] float initialVelocity;
    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ani.SetBool("death", true);
    //    }
    //}
    #endregion



    #region Public Functions

    public void DestroyEnemy()
    {
        ani.enabled = false;
        shells.ForEach((Transform t) =>
        {
            //t.SetParent(null, true);
            Rigidbody rb = t.gameObject.AddComponent<Rigidbody>();
            t.gameObject.GetComponent<MeshCollider>().enabled = true;
            rb.drag = 0f;
            rb.mass = 5f;
            rb.velocity = transform.position + t.position * initialVelocity;
        });
    }
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}