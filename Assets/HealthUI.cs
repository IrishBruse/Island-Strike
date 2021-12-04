using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Sprite full;
    public Sprite half;
    public Sprite empty;
    public Health playerHealth;

    Image[] hearts;
    private void Awake()
    {
        hearts = GetComponentsInChildren<Image>();
    }


    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = half;
            if (i > Mathf.FloorToInt((playerHealth.health - 1) / 2f))
            {
                hearts[i].sprite = empty;
            }
            else if (i < Mathf.CeilToInt((playerHealth.health - 1) / 2f))
            {
                hearts[i].sprite = full;
            }
        }
    }
}
