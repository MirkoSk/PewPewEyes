using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
[CreateAssetMenu(menuName = "Scriptable Objects/FloatValue")]
public class FloatValue : ScriptableObject
{
    public float value;
    public float maxValue;
    public bool respondeWithNullValueEvent;
    [ConditionalHide("respondeWithNullValueEvent", true)]
    public GameEvent nullValueEvent;
    public bool respondeWithFullValueEvent;
    [ConditionalHide("respondeWithFullValueEvent", true)]
    public GameEvent fullValueEvent;

    public void changeValue(float amount)
    {
        value += amount;
        if (value > maxValue)
            value = maxValue;
        if (value < 0)
            value = 0;
        CheckValue();
    }

    private void CheckValue()
    {
        if (value == 0 && respondeWithNullValueEvent)
        {
            nullValueEvent.Raise();
        }
        else if (value == maxValue && respondeWithFullValueEvent)
        {
            fullValueEvent.Raise();
        }
    }
}