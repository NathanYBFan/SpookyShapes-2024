using UnityEngine;

public abstract class GenericSpell
{
    public int powerLevel;
    public SpellType spellType;
    public GameObject spellObject;
    public bool isAOE;

    public void SetPowerLevel(int newPowerLevel)
    {
        powerLevel = newPowerLevel;
    }

    public void SetIsAOI(bool isAOI) { isAOE = isAOI; }

    public int GetDamage()
    {
        return powerLevel * GameManager.Instance.SpellDamageMultiplier;
    }
}
