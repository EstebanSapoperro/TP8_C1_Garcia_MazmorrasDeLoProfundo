using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayExitButton : MonoBehaviour
{
    // Suggestion: Tres bools excluyentes para el tipo de botón. Un enum ButtonType es más claro y evita combinaciones inválidas.
    [SerializeField] private bool playButton = false;
    [SerializeField] private bool mainMenuButton = false;
    [SerializeField] private bool exitButton = false;

    [SerializeField] private Button buttonSelected;

    private void Awake()
    {
        buttonSelected.onClick.AddListener(onClick);
    }


    private void OnDestroy()
    {
        buttonSelected.onClick.RemoveAllListeners();
    }

    private void onClick()
    {
        if (mainMenuButton)
        {
            //DataGameManager.isFinished = false;
            Time.timeScale = 0.0f;
            // Warning: Nombres de escena como strings mágicos ("MainMenu", "Gameplay", también en RetryButton). Centralizalos en constantes.
            SceneManager.LoadScene("MainMenu");
        }

        if (playButton)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Gameplay");
        }

        if (exitButton)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        }

    }
}
