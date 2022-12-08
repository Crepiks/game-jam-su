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

    [SerializeField] private Animator animator;

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
        if (inCollider)
        {
            if (Input.GetKey(KeyCode.E))
            {
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
    }
}
