using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.PlayerLoop;

public class EnemyTurretController : MonoBehaviour
{
    public Transform head;

    float shootTimer;
    GunController gunController;
    TurretState state = TurretState.Idle;
    Transform target;

    float reloadTimer;

    private void Awake()
    {
        target = FindObjectOfType<PlanePlayerInput>(true).transform;
        gunController = GetComponentInChildren<GunController>();
    }

    private void OnEnable()
    {
        shootTimer = Random.Range(4, 8f);
    }

    private void Update()
    {
        gunController.shotPrimary = false;
        gunController.accurate = false;
        switch (state)
        {
            case TurretState.Idle:
                if (Vector3.Distance(transform.position, target.position) < 10)
                {
                    state = TurretState.TargetShoot;
                }
                break;

            case TurretState.TargetShoot:
                gunController.shotPrimary = true;
                head.LookAt(target.position);

                if (gunController.ammo <= 0)
                {
                    state = TurretState.Reloading;
                }
                break;

            // case TurretState.SpinShoot:
            //     head.transform.Rotate(Time.deltaTime * 90, 0, 0);
            //     gunController.shotPrimary = true;

            //     if (gunController.ammo <= 0)
            //     {
            //         state = TurretState.Reloading;
            //     }
            //     break;


            case TurretState.Reloading:
                if (reloadTimer >= 6f)
                {
                    reloadTimer = 0;
                    gunController.Reload();
                }
                else
                {
                    reloadTimer += Time.deltaTime;
                }

                if (gunController.ammo > 0)
                {
                    state = TurretState.Idle;
                }
                break;
        }


    }

    public enum TurretState
    {
        Idle,
        TargetShoot,
        Reloading,
        // SpinShoot,
    }
}
