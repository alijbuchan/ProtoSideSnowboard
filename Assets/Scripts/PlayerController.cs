using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] private float slowSpeed = 5f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        // we push up, then speed up, other wise stay at normal speed.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            surfaceEffector2D.speed = slowSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }


    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
