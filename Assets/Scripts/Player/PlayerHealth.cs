using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerSo data;
    public static event Action OnUpdateHealth;
    public static event Action OnDeathHealth;

    // Suggestion: isDeath, invulneravilityTime, invulneravilityCounter y contactDamage se asignan pero nunca se leen. Código muerto.
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

    // Error: Recibir daño no tiene sonido ni animación (consigna J6: todas las acciones animadas y con sonido).
    // Tampoco se verifica isDeath, así que golpes posteriores a la muerte vuelven a invocar OnDeathHealth.
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
        // Suggestion: Curación 30 hardcodeada, también usada en HeartPick. Llevala a PlayerSo.
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
