using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * moveSpeed;
        mouseRotation = Input.GetAxis("Mouse X") * rotationSpeed;

        Debug.Log(mouseRotation);

        /*
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Translate(Vector3.right * hInput * Time.deltaTime);
        */
    }

    private void FixedUpdate()
    {
        float fixedDeltaTime = Time.fixedDeltaTime;
        rigidBody.MovePosition(
            this.transform.position +
            (this.transform.forward * vInput * fixedDeltaTime) +
            (this.transform.right * hInput * fixedDeltaTime)
        );

        if (mouseRotation != 0)
        {
            Vector3 rotation = Vector3.up * mouseRotation;
            Quaternion rotationAngle = Quaternion.Euler(rotation * Time.fixedDeltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * rotationAngle);
        }
    }
}
