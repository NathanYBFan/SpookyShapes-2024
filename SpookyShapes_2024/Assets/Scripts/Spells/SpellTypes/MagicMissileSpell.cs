public class MagicMissileSpell : GenericSpell
{
    private int numberOfTargets = 3;

    public MagicMissileSpell()
    {
        spellType = SpellType.FIREBALL;
        spellObject = GameManager.Instance?.SpellGOList[2];
        SetPowerLevel(6);
        isAOE = true;
    }
}
