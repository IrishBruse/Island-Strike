using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour
{
    public GunController playerGun;
    public EndlessScoreManager missions;
    [Space]
    public GameObject bluePlanePrefab;
    public GameObject greenPlanePrefab;
    public GameObject yelloPlanePrefab;
    [Space]
    public GameObject turretPrefab;
    public Transform[] turretSpawnLocations;
    [Space]
    public GameObject bombRefil;

    bool refilInMap = false;

    private void OnEnable()
    {
        SimplePool.Spawn(bombRefil, new Vector2(0, 0), Quaternion.identity);

        StartCoroutine("PlaneSpawner");
        StartCoroutine("TurretSpawner");
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    IEnumerator PlaneSpawner()
    {
        while (true)
        {
            if (FindObjectsOfType<PlaneEnemyInput>().Length < 2)
            {
                int weight = Random.Range(0, 45);
                GameObject spawn;
                if (weight < 20)
                {
                    spawn = bluePlanePrefab;
                }
                else if (weight < 35)
                {
                    spawn = greenPlanePrefab;
                }
                else
                {
                    spawn = yelloPlanePrefab;
                }

                SimplePool.Spawn(spawn, new Vector2(Random.Range(-32, 32), Random.Range(-32, 32)), Quaternion.identity);
            }

            yield return new WaitForSeconds(10f);
        }
    }
    IEnumerator TurretSpawner()
    {
        while (true)
        {
            var turrets = FindObjectsOfType<EnemyTurretController>().Length;
            if (turrets < 4)
            {
                int weight = Random.Range(0, 30);

                if (weight < 10)
                {
                    SimplePool.Spawn(turretPrefab, turretSpawnLocations[Random.Range(0, turretSpawnLocations.Length)].position, Quaternion.identity);
                }
            }

            if (playerGun.bombAmmo < turrets)
            {
                if (refilInMap == false)
                {
                    SimplePool.Spawn(bombRefil, new Vector2(Random.Range(-32, 32), Random.Range(-32, 32)), Quaternion.identity);
                    refilInMap = true;
                }
            }
            else
            {
                refilInMap = false;
            }

            yield return new WaitForSeconds(10f);
        }
    }

}
