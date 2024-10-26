public class LightningSpell : GenericSpell
{
    public LightningSpell()
    {
        spellType = SpellType.FIREBALL;
        spellObject = GameManager.Instance?.SpellGOList[2];
        SetPowerLevel(6);
        isAOE = false;
    }
}
