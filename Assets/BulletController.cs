using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 1;
    public GameObject HitPrefab;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine("Despawn");
    }

    private void OnDisable()
    {
        Delete();
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(2);
        Delete();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("triggered");
        SimplePool.Spawn(HitPrefab, transform.position, quaternion.identity);
        Delete();
    }

    void Delete()
    {
        SimplePool.Despawn(gameObject);
        rb.velocity = Vector2.zero;
    }
}
