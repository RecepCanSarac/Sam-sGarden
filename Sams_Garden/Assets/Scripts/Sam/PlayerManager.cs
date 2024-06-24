using System;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public SOPlayer player;
    public float currentXP;

    public float currentHealth { get; private set; }

    private void OnEnable()
    {
        Experiance.experiance += XPAdded;
    }
    private void OnDisable()
    {
        Experiance.experiance -= XPAdded;
    }

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


    public void XPAdded(float x)
    {
        currentXP += x;
        Debug.Log("CALIÞTI");
    }


}
