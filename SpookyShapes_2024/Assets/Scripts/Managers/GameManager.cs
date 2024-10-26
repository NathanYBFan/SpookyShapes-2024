using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonBase<GameManager>
{
    // Public static variables
    public static GameStateMachine stateMachine = new GameStateMachine();

    #region Getters & Setters
    public SpellNameLimiterBase SelectedLimiter { get => selectedLimiter; set => selectedLimiter = value; }
    public GenericSpell SelectedSpell { get => selectedSpell; set => selectedSpell = value; }

    public int SpellDamageMultiplier { get => spellDamageMultiplier; set => spellDamageMultiplier = value; }
    public InputActionAsset PlayerInputAction { get => playerInputAction; }
    public GameObject MainPlayer { get => mainPlayer; }
    public GameObject SpellSpawnPosGO { get => spellSpawnPosGO; }
    #endregion

    #region Serialize Fields
    [SerializeField] private InputActionAsset playerInputAction;
    [SerializeField] private GameObject mainPlayer;
    [SerializeField] private TMP_InputField playerInputField;
    [SerializeField] private GameObject spellSpawnPosGO;
    #endregion

    #region Private Variables
    // Selected elements
    private SpellNameLimiterBase selectedLimiter;
    private GenericSpell selectedSpell;
    // Damage multiplier
    private int spellDamageMultiplier;
    #endregion

    private void Start()
    {
        playerInputField.onFocusSelectAll = true;
        stateMachine.ChangeState(stateMachine.menuState);
        ResetFocusOnInputField();
    }

    public void GameLoop()
    {
        // player attacks
        // timer ticks down
        // on timer == 0 enemy will attack;
        // repeat
    }

    public void ResetFocusOnInputField()
    {
        if (!playerInputField.isActiveAndEnabled)
        {
            playerInputField.enabled = true;
            playerInputField.gameObject.SetActive(true);
        }

        playerInputField.text = string.Empty;
        playerInputField.ActivateInputField();
        playerInputField.Select();
    }

    public void MenuSetup()
    {

    }

    public void GameOver()
    {

    }
}
