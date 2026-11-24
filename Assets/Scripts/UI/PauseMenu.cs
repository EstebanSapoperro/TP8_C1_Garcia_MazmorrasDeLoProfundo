using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup pauseMenu;
    void Update()
    {
        // Bug: Escape no consulta si el juego terminó. Con el panel de Game Over o de victoria abierto (timeScale = 0),
        // apretar Escape dos veces deja Time.timeScale = 1 y el juego sigue corriendo detrás del panel.
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            // Warning: Comparación de float con == sobre alpha. Llevá un bool isPaused.
            if (pauseMenu.alpha == 0)
            {
                Time.timeScale = 0;
                pauseMenu.alpha = 1;
                pauseMenu.interactable = true;
                pauseMenu.blocksRaycasts = true;
            }
            else 
            {
                Time.timeScale = 1;
                pauseMenu.alpha = 0;
                pauseMenu.interactable = false;
                pauseMenu.blocksRaycasts = false;
            }
        }
    }
}
