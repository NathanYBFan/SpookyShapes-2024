using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : GenericSpell
{
    public FireballSpell()
    {
        spellType = SpellType.FIREBALL;
        spellObject = GameManager.Instance?.SpellGOList[0];
        SetPowerLevel(5);
        isAOE = true;
    }
}
