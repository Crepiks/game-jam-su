using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GivingSoulsHintText : MonoBehaviour
{
    private TextMeshProUGUI hintText;
    
    void Start()
    {
        hintText = GetComponent<TextMeshProUGUI>();
    }

    public void showHintText()
    {
        hintText.text = "Нажмите E, чтобы освободить души";
    }

    public void hideHintText()
    {
        hintText.text = "";
    }
}
