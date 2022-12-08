using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CampfireEnterCollisionUI : MonoBehaviour
{
    private TextMeshProUGUI hintText;

    void Start()
    {
        hintText = GetComponent<TextMeshProUGUI>();
    }

    public void showHintText()
    {
        hintText.text = "Нажмите E, чтобы взять душу";
    }

    public void hideHintText()
    {
        hintText.text = "";
    }
}
