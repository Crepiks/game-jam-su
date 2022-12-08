using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskUI : MonoBehaviour
{
    private TextMeshProUGUI taskText;
    private string initialText = "�������� ���� �� �������: ";

    void Start()
    {
        taskText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTaskText(SoulsCollecting soulsCollectingClass)
    {
        if (soulsCollectingClass.numberOfSouls == 3)
        {
            taskText.text = "��������� ���� �� �������� ������ � ���������� ��";
        }
        else
        {
            taskText.text = initialText + soulsCollectingClass.numberOfSouls + "/3";
        }
    }

    public void FinishText()
    {
        taskText.text = "��������� ������� � ����������";
    }
}
