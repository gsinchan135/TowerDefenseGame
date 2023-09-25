using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform parent;
   
    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float restTime = 5f;
    [SerializeField] private float difficultyScale = 0.75f;
    [SerializeField] private int currentWave = 1;
    [SerializeField] private float timeSinceLastSpawn;
    [SerializeField] private int enemiesAlive;
    [SerializeField] private int enemiesNotSpawned;
    [SerializeField] private bool isSpawning = false;

    [Header("Events")]
    public static UnityEvent onEnemyDestroyed = new UnityEvent();

    

    private void Awake(){
        onEnemyDestroyed.AddListener(EnemyDestroyed);
    }

    private void Start(){
        StartCoroutine(StartWave());
    }

    private void Update(){


        if(!isSpawning)
            return;

        //accumulates time since last spawn
        timeSinceLastSpawn += Time.deltaTime;

        //if time for enemy spawn rate has passed and there are enemies left to be spawned
        if(timeSinceLastSpawn >= (1f/enemiesPerSecond) && enemiesNotSpawned>0){
            SpawnEnemy();
            enemiesNotSpawned--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        //no more enemy and no more to be spawned
        if(enemiesAlive <= 0 && enemiesNotSpawned <=0){
            EndWave();
        }
    }
    
    private void EnemyDestroyed(){
        enemiesAlive--;
    }

    //As an IEnum StartWave can be used in a coroutine and the coroutine makes it easier to wait inbetween wave
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(restTime);
        isSpawning = true;
        enemiesNotSpawned = EnemiesPerWave();
    }

    private void EndWave(){
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy(){
        
        GameObject prefabToSpawn = enemyPrefabs[0];
        //Vector3 start = (LevelManager.main.startPoint).position;
        Vector3 start = new Vector3(-13.75f,-0.5f,0f);
        //LevelManager.main.startPoint.position
        Instantiate(prefabToSpawn,start,Quaternion.identity,parent);
    }

    private int EnemiesPerWave(){
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave,difficultyScale));
    }
}
