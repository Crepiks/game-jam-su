using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CampfireEnterColider : MonoBehaviour
{
    [SerializeField] GameObject campfireParticles;
    [SerializeField] GameObject soulsParticles;

    private bool inCollider;
    private bool enabled = true;

    public UnityEvent<CampfireEnterColider> onEnterTrigger;
    public UnityEvent<CampfireEnterColider> onExitTrigger;
    public UnityEvent<CampfireEnterColider> onSoulTaken;

    [SerializeField] private Animator animator;

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
        if (inCollider && enabled)
        {
            if (Input.GetKey(KeyCode.E))
            {
                enabled = false;
                onExitTrigger.Invoke(this);

                animator.SetBool("isTakingSoul", true);
                StartCoroutine(afterAnimation(1.09f));
            }
        }
    }

    IEnumerator afterAnimation(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        animator.SetBool("isTakingSoul", false);
        campfireParticles.SetActive(true);
        soulsParticles.SetActive(true);

        onSoulTaken.Invoke(this);
    }
}
