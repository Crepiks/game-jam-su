using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsCollecting : MonoBehaviour
{
    public int numberOfSouls { get; private set; }

    public void soulCollected()
    {
        numberOfSouls++;
    }
}
