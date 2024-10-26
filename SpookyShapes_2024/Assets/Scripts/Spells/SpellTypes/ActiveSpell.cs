using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSpell : MonoBehaviour
{
    public int powerLevel;
    public SpellType spellType;
    public bool isAOE;

    public void Initialize(GenericSpell spell)
    {
        powerLevel = spell.powerLevel;
        spellType = spell.spellType;
        isAOE = spell.isAOE;
    }

    public void SetPowerLevel(int newPowerLevel)
    {
        powerLevel = newPowerLevel;
    }

    public int GetDamage()
    {
        return powerLevel * GameManager.Instance.SpellDamageMultiplier;
    }
}
