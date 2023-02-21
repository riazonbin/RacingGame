using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemySprites = new List<GameObject>();
    public List<Transform> enemySpawnPoints= new List<Transform>();
    public float timeToSpawnNewCar = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        var enemy = Instantiate(enemySprites[Random.Range(0, enemySprites.Count)],
            enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)]);
        yield return new WaitForSeconds(timeToSpawnNewCar);
        yield return StartCoroutine(SpawnEnemy());
    }
}
