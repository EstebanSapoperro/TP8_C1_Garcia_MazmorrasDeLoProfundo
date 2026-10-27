using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        //scoreText.text = DataGameManager.generalScore.ToString("F0");
    }
}
