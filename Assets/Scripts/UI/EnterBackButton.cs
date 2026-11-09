using UnityEngine;
using UnityEngine.UI;

public class EnterBackButton : MonoBehaviour
{
    [SerializeField] private bool IsResumeButton = false;
    [SerializeField] private CanvasGroup enterPanel;
    [SerializeField] private CanvasGroup exitPanel;
    [SerializeField] private GameObject timePanel;

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

        if (IsResumeButton == true)
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;

            }
            else if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }

            if (timePanel != null)
            {
                //timePanel.SetActive(true);
            }

        }
        Debug.Log("Botón presionado: " + gameObject.name);

        Debug.Log("EnterPanel: " + (enterPanel == null ? "NULL" : enterPanel.name));
        Debug.Log("ExitPanel: " + (exitPanel == null ? "NULL" : exitPanel.name));
        if (enterPanel != null)
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
