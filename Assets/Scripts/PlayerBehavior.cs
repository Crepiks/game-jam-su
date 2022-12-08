using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Transform camera;
    private CharacterController controller;

    public float moveSpeed = 10f;
    public float turnSmoothSpeed = 0.1f;

    private float vInput;
    private float hInput;

    float turnSmoothVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * moveSpeed;


        Vector3 movementDirection = new Vector3(hInput, 0, vInput).normalized;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * moveSpeed;

        if (movementDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothSpeed);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 angleDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.SimpleMove(angleDirection.normalized * magnitude);
        }
    }
}
