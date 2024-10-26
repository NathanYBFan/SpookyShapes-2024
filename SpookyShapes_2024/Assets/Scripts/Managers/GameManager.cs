using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonBase<GameManager>
{
    // Public static variables
    public static GameStateMachine stateMachine = new GameStateMachine();
    
    // Setters & Getters
    public SpellNameLimiterBase SelectedLimiter { get => selectedLimiter; set => selectedLimiter = value; }
    public GenericSpell SelectedSpell { get => selectedSpell; set => selectedSpell = value; }

    public int SpellDamageMultiplier { get => spellDamageMultiplier; set => spellDamageMultiplier = value; }
    public InputActionAsset PlayerInputAction { get => playerInputAction; }

    // Serialize Fields
    [SerializeField] private InputActionAsset playerInputAction;

    // Private variables
    private SpellNameLimiterBase selectedLimiter;
    private GenericSpell selectedSpell;

    private int spellDamageMultiplier;

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.menuState);
    }

    public void MenuSetup()
    {

    }

    public void GameOver()
    {

    }
}
