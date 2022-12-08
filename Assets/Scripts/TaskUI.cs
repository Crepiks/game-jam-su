using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskUI : MonoBehaviour
{
    private TextMeshProUGUI taskText;
    private string initialText = "Соберите души из костров: ";

    void Start()
    {
        taskText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTaskText(SoulsCollecting soulsCollectingClass)
    {
        taskText.text = initialText + soulsCollectingClass.numberOfSouls + "/3";
    }
}
