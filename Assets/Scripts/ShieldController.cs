using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ShieldController : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] GameObject shield;
    [SerializeField] Transform shieldUpPosition;
    [SerializeField] Transform shieldDownPosition;
    [SerializeField] float liftDuration = 0.3f;
    [SerializeField] LeanTweenType tweenType;

    // Private
    bool shieldUp;
	#endregion
	
	
	
	#region Public Properties
	public bool ShieldUp { get { return shieldUp; } }
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		
	}

    private void Update()
    {
        // Raise shield
        if (Input.GetButtonDown(Constants.INPUT_SHIELD))
        {
            LeanTween.cancelAll(shield);
            LeanTween.moveLocal(shield, shieldUpPosition.localPosition, liftDuration).setEase(tweenType);
            LeanTween.scale(shield, shieldUpPosition.localScale, liftDuration).setOnComplete(() => { shieldUp = true; });
        }
        // Lower shield
        else if (Input.GetButtonUp(Constants.INPUT_SHIELD)) 
        {
            LeanTween.cancelAll(shield);
            LeanTween.moveLocal(shield, shieldDownPosition.localPosition, liftDuration).setEase(tweenType);
            LeanTween.scale(shield, shieldDownPosition.localScale, liftDuration).setOnComplete(() => { shieldUp = false; });
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