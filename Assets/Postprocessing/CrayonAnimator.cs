using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrayonAnimator : MonoBehaviour
{

    public float rotateInterval = .2f;
    public bool randomInitTime = true;
    public bool randomInitRotation = true;

    private float timer = 0;
    //private Material material;
    private 
    void Start()
    {
        if (randomInitTime)
        {
            timer = Random.Range(0, rotateInterval);
        }
        if (randomInitRotation)
        {
            //Gotta fix this up
        }
    }
    void Update()
    {
        if (rotateInterval != 0)
        {
            float oldTimer = timer;
            //Add delta time, loop around
            timer = (timer + Time.deltaTime) % rotateInterval;
            //If the timer has looped around again
            if (oldTimer > timer)
            {
                float rotation = Random.Range(0, Mathf.PI * 2);
                Renderer[] children = GetComponentsInChildren<Renderer>();
                foreach (Renderer rend in children)
                {
                    rend.material.SetFloat("_Rotation", rotation);
                }
            }
        }


    }
}
