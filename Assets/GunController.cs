using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour
{
    [HideInInspector] public bool shotPrimary;
    [HideInInspector] public bool shotSecondary;

    public AudioSource mainShootSound;
    public AudioSource bombShootSound;

    public int maxAmmo = 10;
    public int maxMissiles = 10;
    public int ammo;
    public int bombAmmo;

    public float cooldown = 0.25f;

    public AudioSource reloadSoundeffect;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform[] bulletSpawnLoacations;

    int alternateSpawn = 0;
    float primaryCooldownTimer;

    public bool accurate = true;


    private void Start()
    {
        ammo = maxAmmo;
        bombAmmo += maxMissiles;
    }

    public void Reload()
    {
        ammo = maxAmmo;
        if (reloadSoundeffect != null)
        {
            reloadSoundeffect?.Play();
        }
    }

    private void Update()
    {
        if (shotPrimary && primaryCooldownTimer <= 0 && ammo > 0)
        {
            mainShootSound?.Play();
            if (accurate)
            {
                SimplePool.Spawn(bulletPrefab, bulletSpawnLoacations[alternateSpawn].position, bulletSpawnLoacations[alternateSpawn].rotation);
            }
            else
            {
                SimplePool.Spawn(bulletPrefab, bulletSpawnLoacations[alternateSpawn].position, Quaternion.Euler(bulletSpawnLoacations[alternateSpawn].rotation.eulerAngles.x, bulletSpawnLoacations[alternateSpawn].rotation.eulerAngles.y, bulletSpawnLoacations[alternateSpawn].rotation.eulerAngles.z + Random.Range(-10, 10)));
            }
            alternateSpawn++;
            alternateSpawn %= bulletSpawnLoacations.Length;

            primaryCooldownTimer = cooldown;
            ammo--;
        }
        primaryCooldownTimer -= Time.deltaTime;


        if (shotSecondary && bombAmmo > -1)
        {
            if (bombAmmo <= 0)
            {
                if (SceneManager.GetActiveScene().name != "Tutorial" && SceneManager.GetActiveScene().name != "Endless")
                {
                    gameObject.SetActive(false);
                    FindObjectOfType<DeadScreen>(true).gameObject.SetActive(true);
                    FindObjectOfType<DeadScreen>(true).transform.GetChild(0).GetComponent<TMP_Text>().text = "Game Over\n Out of bombs";
                }
            }
            else
            {
                bombShootSound?.Play();
                SimplePool.Spawn(missilePrefab, transform.position, transform.rotation);

                bombAmmo--;
            }
        }
    }
}
