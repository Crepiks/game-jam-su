using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoulsCollecting : MonoBehaviour
{
    public UnityEvent<SoulsCollecting> onSoulTaken;

    public int numberOfSouls { get; private set; }

    public void soulCollected()
    {
        numberOfSouls++;
        onSoulTaken.Invoke(this);
    }
}
