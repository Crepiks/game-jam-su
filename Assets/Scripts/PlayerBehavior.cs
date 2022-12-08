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
    private float mouseRotation;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //float fixedDeltaTime = Time.fixedDeltaTime;
        //rigidBody.MovePosition(
        //  this.transform.position +
        //(this.transform.forward * vInput * fixedDeltaTime) +
        // (this.transform.right * hInput * fixedDeltaTime)
        //);

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * moveSpeed;
        mouseRotation = Input.GetAxis("Mouse X") * rotationSpeed;

        Vector3 movementDirection = new Vector3(hInput, 0, vInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //if (mouseRotation != 0)
        //{
        //    Vector3 rotation = Vector3.up * mouseRotation;
        //    Quaternion rotationAngle = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        //    rigidBody.MoveRotation(rigidBody.rotation * rotationAngle);
        //}
    }
}
