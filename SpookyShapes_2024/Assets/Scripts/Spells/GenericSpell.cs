public abstract class GenericSpell
{
    public int powerLevel;
    public SpellType spellType;

    public void SetPowerLevel(int newPowerLevel)
    {
        powerLevel = newPowerLevel;
    }

    public int GetDamage()
    {
        return powerLevel * GameManager.Instance.SpellDamageMultiplier;
    }
}
