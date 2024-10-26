public class LightningSpell : GenericSpell
{
    public LightningSpell()
    {
        spellType = SpellType.FIREBALL;
        spellObject = GameManager.Instance?.SpellGOList[3];
        SetPowerLevel(6);
        isAOE = false;
    }
}
