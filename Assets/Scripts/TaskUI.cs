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
        if (soulsCollectingClass.numberOfSouls == 3)
        {
            taskText.text = "Проведите души до мирового дерева и освободите их";
        }
        else
        {
            taskText.text = initialText + soulsCollectingClass.numberOfSouls + "/3";
        }
    }

    public void FinishText()
    {
        taskText.text = "Следующие разделы в разработке";
    }
}
