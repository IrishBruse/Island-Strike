using UnityEngine;

public class BombRefil : MonoBehaviour
{
    public AudioSource reloadSound;
    public GunController gunController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BombRefil"))
        {
            gunController.bombAmmo = gunController.maxMissiles;
            reloadSound.Play();
            SimplePool.Despawn(other.gameObject);
        }
    }
}
