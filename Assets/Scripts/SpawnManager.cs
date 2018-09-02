using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SpawnManager : MonoBehaviour
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] EnemyWave[] enemyWaves;
    [SerializeField] List<GameObject> spawnPoints;

    /*
    [SerializeField] EnemyWave wave1;
    [SerializeField] EnemyWave wave2;
    [SerializeField] EnemyWave wave3;
    [SerializeField] EnemyWave bossWave;
    */
    // Private
    private List<GameObject> spawnedEnemies;
    private bool spawning;
    private int spawnedEnemiesCount = 0;
    private bool changeWave;
    private float timer = 0f;
    private EnemyWave currentWave;
    private LinkedList<EnemyWave> waves;

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Awake()
    {
        spawnedEnemies = new List<GameObject>();
        waves = new LinkedList<EnemyWave>();
        foreach (EnemyWave wave in enemyWaves)
        {
            waves.AddLast(wave);
        }
    }
    private void Start()
    {
        currentWave = waves.First.Value;
        spawning = true;
        currentWave.type1Amount = Mathf.RoundToInt((float)currentWave.enemyAmount * currentWave.type1Ratio);
        currentWave.type2Amount = Mathf.RoundToInt((float)currentWave.enemyAmount * currentWave.type2Ratio);
        changeWave = false;
    }

    private void Update()
    {
        if (spawning)
        {
            timer += Time.deltaTime;
            if (timer >= (float)currentWave.spawnTime / currentWave.enemyAmount && spawnedEnemiesCount <= currentWave.enemyAmount)
            {
                GameObject spawnedEnemy;
                int enemyType = Random.Range(0, 1);
                if (enemyType == 0 && currentWave.type1Amount == 0)
                    enemyType = 1;
                else if (enemyType == 1 && currentWave.type2Amount == 0)
                {
                    enemyType = 0;
                }
                spawnedEnemy = Instantiate(
                    enemyType == 0 ? currentWave.tpye1Enemy : currentWave.type2Enemy,
                    spawnPoints[
                        Random.Range(
                            0,
                            spawnPoints.Count
                            )].transform.position,
                    Quaternion.identity);
                timer = 0f;
                spawnedEnemy.GetComponent<Enemy>().spawnManager = this;
                spawnedEnemies.Add(spawnedEnemy);
                if (enemyType == 1)
                {
                    currentWave.type1Amount -= 1;
                }
                else
                {
                    currentWave.type2Amount -= 1;
                }
                spawnedEnemiesCount += 1;
            }
            else if (spawnedEnemiesCount == currentWave.enemyAmount)
            {
                spawning = false;
            }

        }
        if(spawnedEnemies.Count == 0 && !spawning)
        {
            changeWave = true;
        }

        if (changeWave)
        {
            //Debug.Log(waves.Find(currentWave));
            if (!(waves.Find(currentWave) == waves.Last))
            {
                currentWave = waves.Find(currentWave).Next.Value;
                currentWave.type1Amount = Mathf.RoundToInt((float)currentWave.enemyAmount / currentWave.type1Ratio);
                currentWave.type2Amount = Mathf.RoundToInt((float)currentWave.enemyAmount / currentWave.type2Ratio);
                changeWave = false;
            }
            spawning = true;
        }
    }
    #endregion



    #region Public Functions
    public void UnregisterEnemy(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy)){
            spawnedEnemies.Remove(enemy);
        }
    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}