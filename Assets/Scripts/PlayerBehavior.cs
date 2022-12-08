using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Transform camera;
    private CharacterController controller;
    [SerializeField] private Animator animator;

    public float moveSpeed = 10f;
    public float turnSmoothSpeed = 0.1f;
    public float jumpSpeed = 0.1f;
    public float jumpButtonGracePeriod = 0.2f;

    private float vInput;
    private float hInput;

    private float ySpeed;
    private float originalStepOffset;

    private float initialMoveSpeedValue;

    float turnSmoothVelocity;

    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalStepOffset = controller.stepOffset;
        initialMoveSpeedValue = moveSpeed;
    }

    private void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * moveSpeed;


        Vector3 movementDirection = new Vector3(hInput, 0, vInput).normalized;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * moveSpeed;

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(controller.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            controller.stepOffset = 0;
        }

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = 3 * initialMoveSpeedValue;
            animator.SetBool("isRunning", true);
        } else
        {
            moveSpeed = initialMoveSpeedValue;
            animator.SetBool("isRunning", false);
        }

        if (movementDirection.magnitude >= 0.1f)
        {
            animator.SetBool("isWalking", true);
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothSpeed);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 angleDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            angleDirection.y = ySpeed;

            controller.Move(angleDirection.normalized * magnitude * Time.deltaTime);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
