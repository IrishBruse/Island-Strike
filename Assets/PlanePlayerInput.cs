using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePlayerInput : MonoBehaviour
{
    PlaneController planeController;
    GunController gunController;
    private void Awake()
    {
        planeController = GetComponentInChildren<PlaneController>();
        gunController = GetComponentInChildren<GunController>();
    }
    void Update()
    {
        planeController.input = new Vector2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        gunController.shotPrimary = Input.GetButton("Fire1");
        gunController.shotSecondary = Input.GetButtonDown("Fire2");
        planeController.asleep = false;
    }
}
