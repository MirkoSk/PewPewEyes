using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
[CreateAssetMenu(menuName = "Scriptable Objects/Score")]
public class Score : ScriptableObject 
{
    public int score;

    public void IncreaseScore(int value)
    {
        score += value;
    }
}