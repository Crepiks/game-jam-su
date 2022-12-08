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
    public float jumpSpeed = 0.1f;

    private float vInput;
    private float hInput;

    private float ySpeed;
    private float originalStepOffset;

    float turnSmoothVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalStepOffset = controller.stepOffset;
    }

    private void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * moveSpeed;


        Vector3 movementDirection = new Vector3(hInput, 0, vInput).normalized;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * moveSpeed;

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButton("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            controller.stepOffset = 0;
        }

        float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothSpeed);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 angleDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        angleDirection.y = ySpeed;

        controller.Move(angleDirection.normalized * magnitude * Time.deltaTime);
    }
}
