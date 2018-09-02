using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

/// <summary>
/// 
/// </summary>
public class BossShoot : State
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] BossController boss;
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
        GameObject laser = GameObject.Instantiate(boss.LaserType.laserPrefab, boss.transform.position + boss.transform.forward * 2f, Quaternion.identity);
        laser.GetComponent<Rigidbody>().velocity = boss.transform.forward * boss.LaserType.laserSpeed;
        laser.GetComponent<Laser>().Owner = boss;
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