using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrenchSpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyFight;
    [SerializeField] GameObject enemyFightPos;
    bool willBeActive;
    bool waiting;

    private void Start()
    {
        willBeActive = Random.Range(0, 10) <= 5 ? true : false;
        if (!willBeActive || GameManager.Instance == null) gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        enemyFight.transform.position = enemyFightPos.transform.position;
    }
}
