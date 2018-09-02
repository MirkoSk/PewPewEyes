using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

/// <summary>
/// 
/// </summary>
public class Shoot : State
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject nextState;

    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Start()
    {

    }

    private void OnEnable()
    {
        GameObject laser = GameObject.Instantiate(enemy.LaserType.laserPrefab, transform.position + transform.forward + Vector3.up * 0.5f, Quaternion.identity);
        laser.GetComponent<Rigidbody>().velocity = transform.forward * enemy.LaserType.laserSpeed;
        laser.GetComponent<Laser>().Owner = enemy;
        ChangeState(nextState);
    }

    private void OnDisable()
    {

    }

    private void Update()
    {

    }
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}