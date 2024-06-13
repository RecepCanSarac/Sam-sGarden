using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public SOEnemy enemy;
    public float curretHealth { get; private set; }
    private float fireRate = 1.0f;
    private float nextTimeFireRate = 0.0f;

    private void Start()
    {
        curretHealth = enemy.health;
    }
    public void TakeDamage(float damage)
    {
        curretHealth -= damage;

        if (curretHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
            if (Time.time > nextTimeFireRate)
            {
                nextTimeFireRate = Time.time + 1 / fireRate;
                player.TakeDamage(enemy.damage);
            }
        }
    }


}
