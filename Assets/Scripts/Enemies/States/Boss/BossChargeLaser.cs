using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

/// <summary>
/// 
/// </summary>
public class BossChargeLaser : State
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] BossController boss;
    [SerializeField] float chargeDuration = 2f;
    [SerializeField] GameObject nextState;
    [SerializeField] ParticleSystem chargeParticleSystem;

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
        chargeParticleSystem.Play();
        boss.Animator.SetTrigger("chargeLaser");
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        boss.transform.LookAt(GameManager.Instance.Player.transform.position
            + GameManager.Instance.Player.GetComponent<CharacterController>().velocity
            * Vector3.Distance(boss.transform.position, GameManager.Instance.Player.transform.position) / boss.LaserType.laserSpeed);
    }
    #endregion



    #region Public Functions
    public void ShootLaser()
    {

    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}