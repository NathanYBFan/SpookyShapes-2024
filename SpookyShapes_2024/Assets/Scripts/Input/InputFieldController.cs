using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class InputFieldController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    private void Awake()
    {
        inputField.onSubmit.AddListener(ProcessInput);
    }

    private void ProcessInput(string input)
    {
        GameManager.Instance.ResetFocusOnInputField();

        // MENU INPUTS
        if (GameManager.stateMachine.GetCurrentState() == GameManager.stateMachine.menuState)
        {
            if (!DictionaryManager.Instance.CheckValidMenuInput(input)) return;
            else
                RunMenuCommand(input);
        }

        // ADD SPELL
        else if (GameManager.stateMachine.GetCurrentState() == GameManager.stateMachine.addSpellState)
        {
            if (GameManager.Instance.SelectedLimiter != null && GameManager.Instance.SelectedLimiter.ValidInput(input)) return;
            if (DictionaryManager.Instance.InsertNewSpell(input, GameManager.Instance.SelectedSpell)) return;
            else
            {
                // Invalid output answer
            }
        }

        // FIGHT
        else if (GameManager.stateMachine.GetCurrentState() == GameManager.stateMachine.fightingState)
        {
            GenericSpell spellToCast = DictionaryManager.Instance.TryToGetSpell(input);

            if (spellToCast == null)
            {
                return; // Should Throw error
            }

            // Valid spell
            GameManager.Instance.SpawnSpell(spellToCast);
        }

        // Travel
        else if (GameManager.stateMachine.GetCurrentState() == GameManager.stateMachine.travelState)
        {

        }

        // ERROR
        else
        {

        }
    }

    private void RunMenuCommand(string input)
    {
        if (input.CompareTo(DictionaryManager.MenuInputs[0]) == 0       // GO
            || input.CompareTo(DictionaryManager.MenuInputs[1]) == 0    // PLAY
            || input.CompareTo(DictionaryManager.MenuInputs[2]) == 0)   // START
        {
            StartGame();
        }
        else if (input.CompareTo(DictionaryManager.MenuInputs[3]) == 0) // OPTIONS
        {
            LevelLoadManager.Instance.LoadMenuOverlay(LevelLoadManager.LevelNamesList[2]);
        }
        else if (input.CompareTo(DictionaryManager.MenuInputs[4]) == 0) // QUIT
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
        }
        else
            {
            // Not valid command state
        }
    }

    private void StartGame()
    {
        LevelLoadManager.Instance.StartLoadNewLevel(LevelLoadManager.LevelNamesList[1], true);
        GameManager.Instance.StartGame();
    }
}
