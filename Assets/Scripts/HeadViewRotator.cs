using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HeadViewRotator : MonoBehaviour
{
    public float turnSpeed = 3;

    void FixedUpdate()
    {
        KeyboardRotate();
    }

    public void KeyboardRotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, turnSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -turnSpeed, 0);
        }
    }
}
