using System.Collections;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float speed = 1;
    public GameObject explosionPrefab;
    public Shadow2D shadow;

    Rigidbody2D rb;

    float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        timer = .6f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SimplePool.Spawn(explosionPrefab, transform.position, Quaternion.identity);
            Delete();
        }

        shadow.height = timer / .6f;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    void Delete()
    {
        SimplePool.Despawn(gameObject);
        rb.velocity = Vector2.zero;
    }
}
