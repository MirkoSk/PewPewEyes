using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Laser : MonoBehaviour 
{

    #region Variable Declarations

    // Serialized Fields
    public LaserType type;
    // Private
    private int currentReflections = 0;

    public Enemy Owner { get; set;}
    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Start () 
	{
        //Debug.Log("My owner is" + Owner.gameObject.name);
	}


    private void OnCollisionEnter(Collision collision)
    {
        currentReflections += 1;
        if (collision.collider.CompareTag(Constants.TAG_ENEMY))
        {
            Enemy enemy = collision.collider.attachedRigidbody.GetComponent<Enemy>();
            if (enemy == Owner)
            {

            }
            else
            {
                enemy.DealDamage(type.damage);
            }
        }
        if(currentReflections > type.maxReflections)
        {
            Destroy(gameObject);
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