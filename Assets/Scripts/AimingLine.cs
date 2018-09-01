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
    Material mat;
    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Start () 
	{
        lineRenderer = GetComponent<LineRenderer>();
        mat = lineRenderer.material;
        float alphaStart = lineRenderer.startColor.a;
        LeanTween.value(gameObject, UpdateAlpha, alphaStart, 0f, lifeTime).setEase(tweenType).setOnComplete(()=> {
            Destroy(lineRenderer.gameObject);
        });
	}

    private void UpdateAlpha(float value)
    {
        Color oldColor = mat.GetColor("_TintColor");
        Color temp = new Color(oldColor.r, oldColor.g, oldColor.b, value);
        mat.SetColor("_TintColor", temp);
        //lineRenderer.colorGradient.alphaKeys[0].alpha = value;
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