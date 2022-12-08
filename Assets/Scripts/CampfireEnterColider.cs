using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CampfireEnterColider : MonoBehaviour
{
    [SerializeField] GameObject campfireParticles;
    private bool inCollider;

    public UnityEvent<CampfireEnterColider> onEnterTrigger;
    public UnityEvent<CampfireEnterColider> onExitTrigger;

    private void OnTriggerEnter(Collider other)
    {
        onEnterTrigger.Invoke(this);

        inCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        onExitTrigger.Invoke(this);

        inCollider = false;
    }

    private void Update()
    {
        if(inCollider)
        {
            if(Input.GetKey(KeyCode.E))
            {
                campfireParticles.SetActive(true);
            }
        }
    }
}
