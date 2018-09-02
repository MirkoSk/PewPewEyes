using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
[CreateAssetMenu(menuName = "Scriptable Objects/IntValue")]
public class IntValue : ScriptableObject 
{
    public int value;
    public int maxValue;
    public bool respondeWithNullValueEvent;
    [ConditionalHide("respondeWithNullValueEvent", true)]
    public GameEvent nullValueEvent;
    public bool respondeWithFullValueEvent;
    [ConditionalHide("respondeWithFullValueEvent", true)]
    public GameEvent fullValueEvent;
	
    public void changeValue(int amount)
    {
        value += amount;
        if (value > maxValue)
            value = maxValue;
        CheckValue();
    }

    private void CheckValue()
    {
        if(value <= 0 && respondeWithNullValueEvent)
        {
            nullValueEvent.Raise();
        }else if(value >= maxValue && respondeWithFullValueEvent)
        {
            fullValueEvent.Raise();
        }
    }
}