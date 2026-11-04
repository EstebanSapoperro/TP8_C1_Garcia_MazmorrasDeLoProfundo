using UnityEngine;

public class PlayerGameManager : MonoBehaviour
{
    [SerializeField] PlayerSo data;
    public static float actualPlayerHealth;
    void Start()
    {
        actualPlayerHealth = data.Life;
    }

}
