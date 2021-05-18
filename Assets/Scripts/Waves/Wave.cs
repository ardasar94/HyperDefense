using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] GameObject[] enemies;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;
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
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject enemy = Instantiate(enemies[i], path[0].transform.position, Quaternion.identity);
            enemy.transform.parent = this.gameObject.transform;
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    public List<Waypoint> GetPath()
    {
        return path;
    }

    public int WaveEnemiesSize()
    {
        return enemies.Length;
    }
}
