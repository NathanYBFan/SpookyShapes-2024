using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : EntityHP
{
    public override void CheckIfDead()
    {
        if (CurrentHP > 0) return;
        GetComponent<BaseEnemy>().OnDeath();
    }
}
