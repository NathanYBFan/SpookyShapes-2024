using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyHP))]
public class BaseEnemy : MonoBehaviour
{
    // Getter & Setter
    public EnemyData EnemyType { get => enemyType;
        set 
        {
            enemyType = value;
            GetComponent<EnemyHP>().MaxHP = enemyType.maxHP;
            ResetToIdle();
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = enemyType.monsterMat;
        }
    }

    [SerializeField] private EnemyData enemyType;
    [SerializeField] private float maxTime = 2;

    private void OnAttack()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.AttackAnimations[0]);
        yield return new WaitForSeconds(maxTime/2);
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.AttackAnimations[1]);
        yield return new WaitForSeconds(maxTime/2);
        ResetToIdle();
    }

    private void ResetToIdle()
    {
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.IdleFrame);
    }

    public void OnDeath()
    {
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.DeadFrame);
    }
}
