using UnityEngine;

public class PlaneEnemyInput : MonoBehaviour
{
    public float visionCone = 0.1f;

    public AnimationCurve turnSensistivitiy;

    Transform target;

    public EnemyAiState state;


    PlaneController planeController;
    GunController gunController;
    Rigidbody2D rb;

    float patrolTimer = 3f;
    public float changeToSoftFollowTimer = 4;

    bool asleep = true;


    private void Awake()
    {
        target = FindObjectOfType<PlanePlayerInput>().transform;
        planeController = GetComponentInChildren<PlaneController>();
        gunController = GetComponentInChildren<GunController>();
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        planeController.asleep = asleep;
        gunController.accurate = false;

        if (Vector3.Distance(target.transform.position, transform.position) < 15f && asleep == true)
        {
            asleep = false;
        }


        if (asleep)
        {
            return;
        }

        var direction = (target.position - transform.position).normalized;
        var horizontalTurn = 0f;
        gunController.shotPrimary = false;

        if (gunController.ammo <= 0 && state != EnemyAiState.Reloading)
        {
            ChangeState(EnemyAiState.Reloading);
        }

        // foreach (var item in Physics2D.OverlapCircleAll(transform.position, 3f))
        // {
        //     if (item.transform.parent != null)
        //     {
        //         if (item.transform.parent.CompareTag("Player") && state != EnemyAiState.AvoidCrash)
        //         {
        //             ChangeState(EnemyAiState.AvoidCrash);
        //         }
        //     }
        // }

        switch (state)
        {
            case EnemyAiState.Wander:
                if (patrolTimer > 0)
                {
                    patrolTimer -= Time.deltaTime;
                }
                else
                {
                    patrolTimer = 3;
                    ChangeState(EnemyAiState.Persue);
                }
                break;


            case EnemyAiState.Persue:

                var aimDot = Vector3.Dot(direction, transform.up);
                gunController.shotPrimary = aimDot >= 1 - visionCone && Vector3.Distance(target.position, transform.position) < 10f;

                horizontalTurn = turnSensistivitiy.Evaluate(Vector3.Dot(direction, transform.right));

                Debug.DrawRay(transform.position, direction, gunController.shotPrimary ? Color.green : Color.red);
                Debug.DrawRay(transform.position, transform.right * horizontalTurn, Color.blue);
                break;

            case EnemyAiState.Reloading:
                horizontalTurn = 1;
                if (gunController.ammo != 0)
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                        case 1:
                            ChangeState(EnemyAiState.Wander);
                            break;
                        case 2:
                            ChangeState(EnemyAiState.Persue);
                            break;
                    }
                }
                break;

                // case EnemyAiState.AvoidCrash:
                //     horizontalTurn = -1f;
                //     foreach (var item in Physics2D.OverlapCircleAll(transform.position, 3f))
                //     {
                //         if (item.transform.parent != null)
                //         {
                //             if (!item.transform.parent.CompareTag("Player"))
                //             {
                //                 break;
                //             }
                //         }
                //     }

                //     switch (Random.Range(0, 2))
                //     {
                //         case 0:
                //             ChangeState(EnemyAiState.Wander);
                //             break;
                //         case 1:
                //             ChangeState(EnemyAiState.Persue);
                //             break;
                //     }
                //     break;
        }

        planeController.input = new Vector2(Mathf.Clamp(-horizontalTurn, -1, 1), 0);
    }

    void ChangeState(EnemyAiState state)
    {
        // Debug.Log("newState=" + state);
        this.state = state;
    }

    public enum EnemyAiState
    {
        Wander,
        Persue,
        Reloading,
        AvoidCrash,
    }
}
