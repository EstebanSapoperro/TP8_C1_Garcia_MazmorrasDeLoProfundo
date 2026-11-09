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
        maxLife = data.Life;
        actualLife = maxLife;
        invulneravilityTime = data.invulneravilityTime;
        contactDamage = data.contactDamage;
    }

    public void ReciveDamage(float damage) 
    {
        Debug.Log("ESTO ES TEMPORAL, se recivio de daño: " + damage);
        actualLife -= damage;
        Debug.Log("ESTO ES TEMPORAL, la vida actual es: " + actualLife);
        if (actualLife <= 0) 
        {
            Die();
        }
    }

    private void Die() 
    {
        OnDeathHealth?.Invoke();
        isDeath = true;
    }
}
