using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoulRockCollider : MonoBehaviour
{
    [SerializeField] GameObject soulsParticles;
    [SerializeField] SoulsCollecting soulsCollectingClass;
    [SerializeField] private Animator animator;

    private bool inCollider;
    private bool enabled = true;

    public UnityEvent<SoulRockCollider> onEnterTrigger;
    public UnityEvent<SoulRockCollider> onExitTrigger;
    public UnityEvent<SoulRockCollider> onSoulTaken;

    private void OnTriggerEnter(Collider other)
    {
        if (enabled)
        {
            onEnterTrigger.Invoke(this);
        }

        inCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        onExitTrigger.Invoke(this);

        inCollider = false;
    }

    private void Update()
    {
        if (inCollider && enabled && soulsCollectingClass.numberOfSouls == 3)
        {
            if (Input.GetKey(KeyCode.E))
            {
                enabled = false;
                onExitTrigger.Invoke(this);

                animator.SetBool("isGivingSouls", true);
                StartCoroutine(afterAnimation(6.14f));
            }
        }
    }

    IEnumerator afterAnimation(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        animator.SetBool("isGivingSouls", false);
        soulsParticles.SetActive(false);

        onSoulTaken.Invoke(this);
    }
}
