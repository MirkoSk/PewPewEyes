using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

/// <summary>
/// 
/// </summary>
public class ChargeLaser : State
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] Enemy enemy;
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
        enemy.Agent.SetDestination(enemy.transform.position);
        chargeParticleSystem.Play();
        enemy.Animator.SetBool("chargeLaser", true);
    }

    private void OnDisable()
    {
        enemy.Animator.SetBool("chargeLaser", false);
    }

    private void Update()
    {
        enemy.transform.LookAt(GameManager.Instance.Player.transform.position 
            + GameManager.Instance.Player.GetComponent<CharacterController>().velocity 
            * Vector3.Distance(enemy.transform.position, GameManager.Instance.Player.transform.position) / enemy.EnemyType.laserSpeed);
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