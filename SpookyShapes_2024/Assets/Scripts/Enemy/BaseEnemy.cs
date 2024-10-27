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
    public bool IsDead { get => isDead; }


    [SerializeField] private EnemyData enemyType;
    [SerializeField] private float maxAnimationTime = 1f;

    public bool isDead = false;
    private float attackTimer = 0;
    private float maxAttackTimer = 7;

    private void Start()
    {
        attackTimer = maxAttackTimer;
    }


    private void Update()
    {
        if (isDead) return;

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            OnAttack();
            attackTimer = maxAttackTimer;
        }

    }


    private void OnAttack()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.AttackAnimations[0]);
        yield return new WaitForSeconds(maxAnimationTime / 2);
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.AttackAnimations[1]);
        yield return new WaitForSeconds(maxAnimationTime / 2);
        ResetToIdle();
    }

    private void ResetToIdle()
    {
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.IdleFrame);
    }

    public void OnDeath()
    {
        isDead = true;
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.DeadFrame);
        StopAllCoroutines();
        StartCoroutine(DeathEffects());
    }

    private IEnumerator DeathEffects()
    {
        // Play effect
        // Play sound
        enemyType.monsterMat.SetTexture("_MainTex", enemyType.DeadFrame);

        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
