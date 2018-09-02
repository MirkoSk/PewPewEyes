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

    // Private
    float timer;
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
        enemy.Animator.SetBool("chargeLaser", true);
        timer = 0f;
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

        if (enemy.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && timer > 1f)
        {
            ChangeState(nextState);
        }

        timer += Time.deltaTime;
    }
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}