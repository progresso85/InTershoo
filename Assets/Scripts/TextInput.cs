using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInput : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textInput;

    public void SetText(string text)
    {
        textInput.text = text;
    }
}
