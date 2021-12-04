using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlaneController : MonoBehaviour
{
    [HideInInspector] public Vector2 input;

    public float maxSpeed = 7;
    public float maxTurnRate = 4;

    public bool asleep = true;

    Rigidbody2D rb;
    GunController gunController;

    float oldTurnDirection;
    float startTurnAngle;
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        gunController = GetComponent<GunController>();
    }

    private void Update()
    {
        if (input.x != 0)
        {
            if (input.x != oldTurnDirection)
            {
                startTurnAngle = rb.rotation;
            }
            else
            {
                if (Mathf.Abs(startTurnAngle - rb.rotation) > 360)
                {
                    startTurnAngle = rb.rotation;
                    gunController.Reload();
                }
            }
        }

        oldTurnDirection = input.x;
    }

    private void FixedUpdate()
    {
        if (asleep)
        {
            return;
        }

        rb.AddTorque(input.x * maxTurnRate);
        rb.velocity = maxSpeed * transform.up;
    }
}
