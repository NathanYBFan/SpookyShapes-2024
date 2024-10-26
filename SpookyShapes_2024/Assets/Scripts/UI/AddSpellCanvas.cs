using UnityEngine;

public class AddSpellCanvas : MonoBehaviour
{
    [SerializeField] private NameSpell nameSpellScript;

    // Start is called before the first frame update
    void Start()
    {
        nameSpellScript.InputField.onFocusSelectAll = true;
        nameSpellScript.InputField.text = string.Empty;
        nameSpellScript.InputField.ActivateInputField();
        nameSpellScript.InputField.Select();
    }
}
