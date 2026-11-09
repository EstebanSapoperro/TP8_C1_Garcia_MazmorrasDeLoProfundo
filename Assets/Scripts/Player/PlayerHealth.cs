using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerSo data;
    public static event Action OnUpdateHealth;
    public static event Action OnDeathHealth;

    private bool isDeath = false;
    private float invulneravilityTime = 2;
    private float invulneravilityCounter = 0;
    private float contactDamage;
    private float actualLife;
    private float maxLife;

    private void Start()
    {
        PlayerGameManager.maxPlayerHealth = data.Life;
        PlayerGameManager.playerHealth = PlayerGameManager.maxPlayerHealth;
        maxLife = data.Life;
        actualLife = maxLife;
        invulneravilityTime = data.invulneravilityTime;
        contactDamage = data.contactDamage;
    }

    public void ReciveDamage(float damage) 
    {
        actualLife -= damage;
        PlayerGameManager.playerHealth -= damage;
        OnUpdateHealth?.Invoke();
        if (actualLife <= 0) 
        {
            Die();
        }
    }

    public void RegenHealth() 
    {
        actualLife += 30;
        PlayerGameManager.playerHealth += 30;
        OnUpdateHealth?.Invoke();
    }
    public void RegenMaxHealth()
    {
        actualLife = maxLife;
        PlayerGameManager.playerHealth = PlayerGameManager.maxPlayerHealth;
        OnUpdateHealth?.Invoke();
    }

    private void Die() 
    {
        OnDeathHealth?.Invoke();
        isDeath = true;
    }
}
