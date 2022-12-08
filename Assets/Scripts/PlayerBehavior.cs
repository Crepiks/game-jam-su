using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 5000f;

    private float vInput;
    private float hInput;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * moveSpeed;
       

        Vector3 movementDirection = new Vector3(hInput, 0, vInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * moveSpeed;
        movementDirection.Normalize();

        controller.SimpleMove(movementDirection * magnitude);

        //transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
