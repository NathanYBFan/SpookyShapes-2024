using TMPro;
using UnityEngine;

public class InputFieldController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    private void Awake()
    {
        inputField.onSubmit.AddListener(ProcessInput);
    }

    private void ProcessInput(string input)
    {
        if (GameManager.Instance.SelectedLimiter.ValidInput(input))
        {
            if (DictionaryManager.Instance.InsertNewSpell(input, GameManager.Instance.SelectedSpell))
                return;
            else
            {
                // Invalid output answer
            }
        }
    }
}
