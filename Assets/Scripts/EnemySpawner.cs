using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<Sprite> sprites = new List<Sprite>();
    public List<Transform> enemySpawnPoints= new List<Transform>();
    public float timeToSpawnNewCar = 5f;

#nullable enable
    private Transform? lastPoint;
#nullable disable
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
        var newPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)];
        if (newPoint == lastPoint)
        {
            yield return StartCoroutine(SpawnEnemy());
        }
        var enemy = Instantiate(enemyPrefabs[0], newPoint);
        enemy.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        var test1 = enemy.GetComponent<SpriteRenderer>().sprite.bounds.size;
        var test2 = enemy.GetComponent<CapsuleCollider2D>().size;
        enemy.GetComponent<CapsuleCollider2D>().size = test1;
        lastPoint = newPoint;

        yield return new WaitForSeconds(timeToSpawnNewCar);
        yield return StartCoroutine(SpawnEnemy());
    }
}
