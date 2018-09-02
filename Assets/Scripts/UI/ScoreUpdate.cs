using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 
/// </summary>
public class ScoreUpdate : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] Score score;
    [SerializeField] TextMeshProUGUI text;
    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Update()
    {
        text.text = score.score.ToString();
    }
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}