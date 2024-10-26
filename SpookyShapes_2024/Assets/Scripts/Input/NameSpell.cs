using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameSpell : MonoBehaviour
{
    public TMP_InputField InputField { get => inputField; }

    [SerializeField] private TMP_InputField inputField;
    private void Awake()
    {
        inputField.onSubmit.AddListener(AddSpell);
        GameManager.Instance.SelectedSpell = new FireballSpell();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            InputField.onFocusSelectAll = true;
            InputField.ActivateInputField();
            InputField.Select();
        }
    }

    private void AddSpell(string input)
    {
        inputField.text = string.Empty;
        
        if (input.Length >= 6) return;
        if (DictionaryManager.Instance.InsertNewSpell(input, GameManager.Instance.SelectedSpell))
        {
            LevelLoadManager.Instance.UnloadMenuOverlay(LevelLoadManager.LevelNamesList[3]);


            return;
        } 
        else
        {
            // Invalid output answer
        }
    }
}
