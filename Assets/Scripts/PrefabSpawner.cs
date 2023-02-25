using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private float spawnChance = 50f;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private float spawnDelay = 60f;
    [SerializeField] private GameObject[] prefabs;
    private float nextSpawnTime;

    void Update()
    {
        if (ShouldSpawn())
            Spawn();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;

        float randomMaySpawn = Random.Range(0,100);
        if (randomMaySpawn > spawnChance)
            return;

        Collider2D[] checkInfo = Physics2D.OverlapCircleAll(transform.position, checkRadius);
        foreach (Collider2D obj in checkInfo)
        {
            if (obj.tag == "Plant")
                return;
        }

        GameObject plant = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, transform.rotation, this.transform);
    }
    private bool ShouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }
}
