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

    }
}
