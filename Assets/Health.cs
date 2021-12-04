using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

    public GameObject explosionPrefab;
    bool dead = false;

    private void OnEnable()
    {
        health = maxHealth;
    }

    private void Update()
    {
        // if (CompareTag("Player") && Input.GetKeyDown(KeyCode.F7))
        // {
        //     health = 100;
        // }

        // if (CompareTag("Player") && Input.GetKeyDown(KeyCode.F8))
        // {
        //     gameObject.SetActive(false);
        //     FindObjectOfType<DeadScreen>(true).gameObject.SetActive(true);
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            health--;
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            health = 0;
        }

        if (health <= 0 && dead == false)
        {
            dead = true;

            if (EndlessScoreManager.instance != null && gameObject.layer == LayerMask.NameToLayer("Turret"))
            {
                EndlessScoreManager.instance.turretKills++;
            }

            if (EndlessScoreManager.instance != null && gameObject.layer == LayerMask.NameToLayer("Plane") && !CompareTag("Player"))
            {
                EndlessScoreManager.instance.planeKills++;
            }

            if (!CompareTag("Player"))
            {
                Kill();
            }
            else
            {
                gameObject.SetActive(false);
                FindObjectOfType<DeadScreen>(true).gameObject.SetActive(true);
            }
            SimplePool.Despawn(other.gameObject);
        }
    }

    private void Kill()
    {
        SimplePool.Despawn(gameObject);
        SimplePool.Spawn(explosionPrefab, transform.position, transform.rotation);
    }
}
