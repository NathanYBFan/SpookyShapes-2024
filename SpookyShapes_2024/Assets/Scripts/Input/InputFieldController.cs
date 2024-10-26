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
        if (GameManager.stateMachine.GetCurrentState() == GameManager.stateMachine.menuState)
        {
            if (!DictionaryManager.Instance.CheckValidMenuInput(input)) return;
            else
            {
                RunMenuCommand(input);
            }
        }

        if (GameManager.Instance.SelectedLimiter != null && GameManager.Instance.SelectedLimiter.ValidInput(input))
        {
            if (DictionaryManager.Instance.InsertNewSpell(input, GameManager.Instance.SelectedSpell)) return;
            else
            {
                // Invalid output answer
            }
        }
        else // Cast spell
        {

            //else if (GameManager.stateMachine.GetCurrentState() == GameManager.stateMachine.menuState)
            //GenericSpell spellToCast = DictionaryManager.Instance.TryToGetSpell(input);
            //if (spellToCast != null) return; // Should Throw error

            //// Valid spell
            //spellToCast.SpawnSpell(GameManager.Instance.SpellSpawnPosGO.transform.position);
        }
    }

    private void RunMenuCommand(string input)
    {
        if (input.CompareTo(DictionaryManager.MenuInputs[0]) == 0) // PLAY
        {

        }
        else if (input.CompareTo(DictionaryManager.MenuInputs[1]) == 0) // GO
        {

        }
        else if (input.CompareTo(DictionaryManager.MenuInputs[2]) == 0) // START
        {

        }
        else if (input.CompareTo(DictionaryManager.MenuInputs[3]) == 0) // OPTIONS
        {

        }
        else if (input.CompareTo(DictionaryManager.MenuInputs[4]) == 0) // QUIT
        {

        }
        else
        {
            // Not valid command state
        }
    }
}
