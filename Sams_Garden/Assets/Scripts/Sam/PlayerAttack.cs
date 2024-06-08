using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public SOPlayer player;
    public LayerMask mask;
    private float nextFireTime;
    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, player.Radius, mask);

            if (hit.Length > 0)
            {
                List<Collider2D> closestEnemies = new List<Collider2D>();

                foreach (var item in hit)
                {
                    closestEnemies.Add(item);
                }

                closestEnemies.Sort((a, b) => Vector2.Distance(transform.position, a.transform.position).CompareTo(Vector2.Distance(transform.position, b.transform.position)));

                for (int i = 0; i < player.index && i < closestEnemies.Count; i++)
                {
                    FireAtTarget(closestEnemies[i]);
                }
            }
            nextFireTime = Time.time + 1f / player.fireRate;
        }
    }

    private void FireAtTarget(Collider2D target)
    {

        Debug.Log("Ate� ediliyor: " + target.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4);
    }
}
