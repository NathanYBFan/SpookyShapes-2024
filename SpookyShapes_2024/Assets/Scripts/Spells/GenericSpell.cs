using UnityEngine;

public abstract class GenericSpell : MonoBehaviour
{
    public int powerLevel;
    public SpellType spellType;

    [SerializeField] private GameObject spell;

    public void SetPowerLevel(int newPowerLevel)
    {
        powerLevel = newPowerLevel;
    }

    public int GetDamage()
    {
        return powerLevel * GameManager.Instance.SpellDamageMultiplier;
    }

    public GameObject SpawnSpell(Vector3 spawnPos)
    {
        GameObject createdSpell = Instantiate(spell, spawnPos, Quaternion.identity);

        return createdSpell;
    }
}
