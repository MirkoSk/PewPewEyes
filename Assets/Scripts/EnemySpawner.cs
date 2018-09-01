using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class EnemySpawner : MonoBehaviour
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] List<GameObject> enemies;
    [SerializeField] [MinMaxRange(5f, 30f)] RangedFloat spawnInterval;
    // Private
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        StartCoroutine(SpawnEnemy(Random.Range(0, enemies.Count)));
	}
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions

    #endregion



    #region Coroutines
    IEnumerator SpawnEnemy(int id)
    {
        yield return new WaitForSeconds(Random.Range(spawnInterval.minValue, spawnInterval.maxValue));
        Instantiate(enemies[id], transform.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy(Random.Range(0, enemies.Count)));
    }

    #endregion
}