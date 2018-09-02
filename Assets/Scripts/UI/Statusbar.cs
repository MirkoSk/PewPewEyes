using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class Statusbar : MonoBehaviour
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] bool useFloat = false;

    [ConditionalHide("useFloat", true, true)]
    public IntValue intValue;
    
    [ConditionalHide("useFloat", true)]
    public FloatValue floatValue;
    
    [SerializeField] RectTransform bar;
    [SerializeField] Gradient gradient;
    // Private
    Image image;
    float defaultWidth;
    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Awake()
    {
        image = bar.GetComponent<Image>();
        defaultWidth = bar.sizeDelta.x;
    }

    private void Update()
    {
        float value = useFloat == false ? Mathf.Clamp01((float)intValue.value / intValue.maxValue) : Mathf.Clamp01(floatValue.value / floatValue.maxValue);
        image.color = gradient.Evaluate(value);
        bar.sizeDelta = new Vector2(value * defaultWidth, 1f);
    }
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}