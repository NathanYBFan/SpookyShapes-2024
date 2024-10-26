using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : SingletonBase<DictionaryManager>
{
    // Setters & Getters
    public Dictionary<string, GenericSpell> Spells { get => spells; set => spells = value; }

    // Serialize Fields
    [SerializeField] private SpellNameLimiterBase[] spellNameLimiterBases;

    // Private variables
    private Dictionary<string, GenericSpell> spells = new Dictionary<string, GenericSpell>()
    {
        { "Nathan", new FireballSpell()},
        { "Brendan", new FireballSpell()},
        { "Alysia", new FireballSpell()},
    };

    public void PrintDictionaryDetails()
    {
        foreach (KeyValuePair<string, GenericSpell> spell in Spells)
        {
            Debug.Log("Spell name: " + spell.Key + " Spell function name: " + spell.Value.ToString());
        }
    }

    private bool ExistsInDictionary(string input)
    {
        foreach (KeyValuePair<string, GenericSpell> spell in Spells)
            if (spell.Key == input) return true;
        
        return false;
    }

    public bool InsertNewSpell(string key, GenericSpell newSpell)
    {
        // Error checks
        if (spells == null) return false;
        if (ExistsInDictionary(key)) return false;
        if (newSpell == null) return false;

        // Add Element
        spells.Add(key, newSpell);
        // Passed all checks, successfully added
        return true;
    }
}
