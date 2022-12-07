using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0, 4f, -10f);
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = player.transform.TransformPoint(cameraOffset);
        this.transform.LookAt(player.transform);
    }
}
