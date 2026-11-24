using UnityEngine;

public class PlayerGameManager : MonoBehaviour
{
    // Warning: 'data' no se usa y la vida queda duplicada en estos static public y en PlayerHealth.actualLife.
    // Dos fuentes de verdad para lo mismo. Exponé la vida desde PlayerHealth (property + evento con el valor) y borrá esta clase.
    [SerializeField] PlayerSo data;
    public static float maxPlayerHealth;
    public static float playerHealth;

}
