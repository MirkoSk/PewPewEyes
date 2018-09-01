using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class AimingLine : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] float lifeTime = 3f;
    [SerializeField] LeanTweenType tweenType;

    // Private
    float timer;
    LineRenderer lineRenderer;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        lineRenderer = GetComponent<LineRenderer>();
        float alphaStart = lineRenderer.startColor.a;
        LeanTween.value(gameObject, alphaStart, 0f, lifeTime).setEase(tweenType).setOnUpdate((float value) => 
        {
            lineRenderer.colorGradient.alphaKeys[0].alpha = value;
        });
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