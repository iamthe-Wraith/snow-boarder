using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float speed = 10f;
    [SerializeField] float boostSpeed = 15f;
    private bool hasCrashed = false;
    public bool Crashed
    {
        get
        {
            return hasCrashed;
        }
        private set
        {
            hasCrashed = value;
        }
    }

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    public void DisableControls()
    {
        Crashed = true;
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (!Crashed)
        {
            RotatePlayer();
            Boost();
        }
    }

    private void Boost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = speed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
        rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
        rb2d.AddTorque(-torqueAmount);
        }
    }
}
