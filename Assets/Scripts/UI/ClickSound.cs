using UnityEngine;
using UnityEngine.UI;

// Suggestion: Script vacío (Awake sin cuerpo, buttonSelected y source sin uso) pero agregado en MainMenuCanvas. Borralo.
public class ClickSound : MonoBehaviour
{
    [SerializeField] private Button buttonSelected;
    public AudioSource source;

    private void Awake()
    {

    }


}
