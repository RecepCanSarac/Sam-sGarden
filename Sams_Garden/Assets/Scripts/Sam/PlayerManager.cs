using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public SOPlayer player;

    public float currentHealth { get; private set; }
    void Start()
    {
        currentHealth = player.Health;
    }
    #region TakeDamage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Debug.Log("Oyunu Kaybettin!");
            Destroy(this.gameObject);
        }
    }
    #endregion





}
