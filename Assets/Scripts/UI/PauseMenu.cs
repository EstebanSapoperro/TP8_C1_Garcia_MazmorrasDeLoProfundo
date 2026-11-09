using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
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
