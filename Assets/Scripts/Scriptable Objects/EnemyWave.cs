using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
[CreateAssetMenu(menuName = "Scriptable Objects/Enemy Wave")]
public class EnemyWave : ScriptableObject
{

    public int enemyAmount;

    public GameObject tpye1Enemy;
    [Range(0, 1)]
    public float type1Ratio;
    public GameObject type2Enemy;
    [Range(0, 1)]
    public float type2Ratio;

    public float spawnTime;

    [HideInInspector] public int type1Amount;
    [HideInInspector] public int type2Amount;
}