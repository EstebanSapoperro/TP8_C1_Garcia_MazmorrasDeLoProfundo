using UnityEngine;
using UnityEngine.UI;

public class EnterBackButton : MonoBehaviour
{
    [SerializeField] private bool IsResumeButton = false;
    [SerializeField] private CanvasGroup enterPanel;
    [SerializeField] private CanvasGroup exitPanel;
    [SerializeField] private GameObject timePanel;
    [SerializeField] private AudioSource buttonSFX;

    [SerializeField] private Button exitbutton;
    private void Awake()
    {
        exitbutton.onClick.AddListener(onClick);
    }

    private void OnDestroy()
    {
        exitbutton.onClick.RemoveAllListeners();
    }

    private void onClick()
    {
        buttonSFX.Play();
        if (IsResumeButton == true)
        {
            if (Time.timeScale == 0)
            {
                Debug.Log("el tiempo es 1");
                Time.timeScale = 1;

            }
            else if (Time.timeScale == 1)
            {
                Debug.Log("el tiempo es 0");
                Time.timeScale = 0;
            }

        }

        if (enterPanel != null && !IsResumeButton)
        {
            enterPanel.alpha = 1;
            enterPanel.interactable = true;
            enterPanel.blocksRaycasts = true;
        }
        if (exitPanel != null)
        {
            exitPanel.alpha = 0;
            exitPanel.interactable = false;
            exitPanel.blocksRaycasts = false;
        }
        

    }
}
