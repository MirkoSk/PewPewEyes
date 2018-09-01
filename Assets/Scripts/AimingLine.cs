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
    [Space]
    [SerializeField] AnimationCurve animationCurve;

    // Private
    float timer;
    LineRenderer lineRenderer;
    Material mat;
    Rigidbody rb;
    float lifeTime;
    #endregion



    #region Public Properties
    public float LifeTime { get { return lifeTime; } set { lifeTime = value; } }
    #endregion



    #region Unity Event Functions
    private void Start () 
	{
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();

        mat = lineRenderer.material;
        float alphaStart = lineRenderer.startColor.a;
        LeanTween.value(gameObject, UpdateAlpha, alphaStart, 0f, lifeTime).setEase(animationCurve).setOnComplete(()=> {
           Destroy(gameObject);
        });
	}

    private void UpdateAlpha(float value)
    {
        Color oldColor = mat.GetColor("_TintColor");
        Color temp = new Color(oldColor.r, oldColor.g, oldColor.b, value);
        mat.SetColor("_TintColor", temp);
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