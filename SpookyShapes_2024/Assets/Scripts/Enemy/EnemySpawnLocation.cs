using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnLocation : MonoBehaviour
{
    [SerializeField] EnemyTrenchSpawn ets;
    private void Start()
    {
        ets.enemies.Add(GameManager.Instance.SpawnEnemy(transform.position));
    }
}
