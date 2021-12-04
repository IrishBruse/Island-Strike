using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileAmmoUI : MonoBehaviour
{
    public GunController gunController;

    Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = gunController.bombAmmo + "/" + gunController.maxMissiles;
    }
}
