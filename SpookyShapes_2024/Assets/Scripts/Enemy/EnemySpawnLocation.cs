using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnLocation : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.SpawnEnemy(transform.position);
    }
}
