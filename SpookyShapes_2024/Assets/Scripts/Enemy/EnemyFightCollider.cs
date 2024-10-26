using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.stateMachine.ChangeState(GameManager.stateMachine.fightingState);
        GameManager.Instance.StartFight(transform.parent.gameObject);
    }
}
