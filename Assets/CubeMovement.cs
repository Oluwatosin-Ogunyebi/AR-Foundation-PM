using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody cubeRB;

    private Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Direction.magnitude > 0)
        {
            cubeRB.AddForce(Vector3.forward * moveSpeed);
        }
    }
}
