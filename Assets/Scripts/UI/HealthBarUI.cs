// Suggestion: using TMPro sin usar.
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image fillHealthBarImage;
    // Suggestion: maxHealth y Start() vacío son código muerto.
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
      
    }

}
