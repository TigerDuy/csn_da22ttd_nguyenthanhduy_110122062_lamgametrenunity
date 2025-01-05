using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public float spawnRate = 1.5f;
    public Vector3 spawnSize = new(5f, 5f, 5f);
    private float spawnTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver())
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnSize);
    }

    void SpawnEnemy()
    {
        Vector2 randomPosition = (Vector2)transform.position + (Random.insideUnitCircle.normalized * spawnSize);

        Instantiate(enemyPrefabs, randomPosition, Quaternion.identity);
    }
}
