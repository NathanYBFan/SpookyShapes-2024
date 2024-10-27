using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour
{
    private int damage = 0;

    private void Start()
    {
        DealDamage();
    }

    private void DealDamage()
    {
        damage = GetComponent<ActiveSpell>().GetDamage();
        if (GameManager.Instance.CurrentEnemies == null) return;
        foreach (var enemy in GameManager.Instance.CurrentEnemies)
            enemy.GetComponent<EnemyHP>().TakeDamage(damage);
        StartCoroutine(DestroyYourself());
    }

    private IEnumerator DestroyYourself()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

}
