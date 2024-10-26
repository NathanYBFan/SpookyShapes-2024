using UnityEngine;

public class AcidSpell : GenericSpell
{
    public AcidSpell()
    {
        spellType = SpellType.ACID;
        spellObject = GameManager.Instance?.SpellGOList[1];
        SetPowerLevel(2);
        isAOE = true;
    }
}
