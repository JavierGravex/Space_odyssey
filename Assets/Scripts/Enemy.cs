using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy : MonoBehaviour
{
    [SerializeField] public float radius = 7f;
    [SerializeField] private float _spawnInterval = 2f; // Time between spawns
    [SerializeField] private GameObject _bombPrefab; // Assign the bomb prefab to start spawning

    // Update is called once per frame
    void Update()
    {
        // Spawn a bomb every 5 seconds
        if (Time.time % _spawnInterval < Time.deltaTime)
        {
            SpawnObjectAtRandom();
        }

    }

    void SpawnObjectAtRandom()
    {    
        Vector3 randomPos = Random.insideUnitCircle * radius;

        Instantiate(_bombPrefab, this.transform.position + randomPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
