using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : SingletonBase<DictionaryManager>
{
    // Setters & Getters
    public Dictionary<string, GenericSpell> Spells { get => spells; set => spells = value; }
    
    public static string[] Directions { get => directions; }
    public static string[] MenuInputs { get => menuInputs; }

    // Serialize Fields
    [SerializeField] private SpellNameLimiterBase[] spellNameLimiterBases;

    // Private variables
    private Dictionary<string, GenericSpell> spells = new Dictionary<string, GenericSpell>();

    // Valid direction input
    private static string[] directions =
    {
        "up",
        "down",
        "left",
        "right",
        "forwards",
        "back",
        "go",
        "stop",
    };

    // Valid menu Input
    private static string[] menuInputs =
    {
        "play",
        "go",
        "start",
        "options",
        "quit",
    };

    public void Start()
    {
        InitializeSpellsDictionary();
    }

    public void PrintDictionaryDetails()
    {
        foreach (KeyValuePair<string, GenericSpell> spell in Spells)
        {
            Debug.Log("Spell name: " + spell.Key + " Spell function name: " + spell.Value.ToString());
        }
    }

    #region Spell Dictionary Methods
    public bool InsertNewSpell(string key, GenericSpell newSpell)
    {
        // Error checks
        if (spells == null) return false;
        if (ExistsInSpellDictionary(key)) return false;
        if (newSpell == null) return false;
        
        key = key.ToLower();

        // Add Element
        spells.Add(key, newSpell);
        // Passed all checks, successfully added
        return true;
    }

    public GenericSpell TryToGetSpell(string key)
    {
        spells.TryGetValue(key, out GenericSpell newSpell);
        return newSpell;
    }

    // Private Methods
    private bool ExistsInSpellDictionary(string input)
    {
        input = input.ToLower();
        foreach (KeyValuePair<string, GenericSpell> spell in Spells)
            if (spell.Key == input) return true;

        return false;
    }

    private void InitializeSpellsDictionary()
    {
        spells.Add("nathan", new FireballSpell());
        spells.Add("brendan", new FireballSpell());
        spells.Add("alysia", new FireballSpell());

    }
    #endregion

    #region Menu Input Methods
    public bool CheckValidMenuInput(string input)
    {
        input = input.ToLower();
        foreach(string command in menuInputs)
            if (command.CompareTo(input) == 0) return true;

        return false;
    }
    #endregion
}
