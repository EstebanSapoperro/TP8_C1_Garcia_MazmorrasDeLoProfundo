using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image fillHealthBarImage;
    private float maxHealth = 100;
    private void Awake()
    {
        PlayerHealth.OnUpdateHealth += UpdateHealth;
    }

    private void OnDestroy()
    {
        PlayerHealth.OnUpdateHealth -= UpdateHealth;
    }

    private void Start()
    {

    }
    private void UpdateHealth()
    {
        fillHealthBarImage.fillAmount = PlayerGameManager.playerHealth / PlayerGameManager.maxPlayerHealth;
        Debug.Log("la barra deberia de estar en: " + (int)PlayerGameManager.playerHealth / (int)PlayerGameManager.maxPlayerHealth);
    }

}
