using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrenchSpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyFight;
    [SerializeField] GameObject enemyFightPos;
    [SerializeField] public List<BaseEnemy> enemies = new List<BaseEnemy>();
    bool willBeActive;
    bool waiting;

    private void Start()
    {
        willBeActive = Random.Range(0, 10) <= 5 ? true : false;
        if (!willBeActive || GameManager.Instance == null) gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        enemyFightPos = transform.parent.gameObject;
        enemyFight.transform.position = enemyFightPos.transform.position;
    }

    private void FixedUpdate()
    {
        foreach(BaseEnemy enemy in enemies)
        {
            if (enemy != null && !enemy.IsDead)
                return;
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
