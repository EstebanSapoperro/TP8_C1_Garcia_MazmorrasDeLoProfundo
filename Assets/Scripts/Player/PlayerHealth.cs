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

    private void Start()
    {
        invulneravilityTime = data.invulneravilityTime;
        contactDamage = data.contactDamage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            OnDeathHealth?.Invoke();
            Debug.Log("Esto es TEMPORAL, el jugador murio por causas de admin");
        }
    }
}
