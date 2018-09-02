using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.AI;

/// <summary>
/// 
/// </summary>
public class BossMove : State
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] BossController boss;
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
        timer = 0f;
    }

    private void OnDisable()
    {

    }

    private void Update()
    {
        // Look at player
        if (GameManager.Instance != null) transform.LookAt(GameManager.Instance.Player.transform);

        // check and increase timer
        if (timer >= boss.EnemyType.moveStateDuration)
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