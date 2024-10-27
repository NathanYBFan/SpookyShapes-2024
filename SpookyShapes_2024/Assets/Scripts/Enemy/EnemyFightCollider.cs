using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightCollider : MonoBehaviour
{
    [SerializeField] private EnemyTrenchSpawn ETS;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameManager.Instance.CurrentEnemies = ETS.enemies;
        GameManager.stateMachine.ChangeState(GameManager.stateMachine.fightingState);
        GameManager.Instance.StartFight(transform.parent.gameObject);
        
    }
}
