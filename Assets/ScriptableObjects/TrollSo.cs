using UnityEngine;

[CreateAssetMenu(fileName = "TrollData", menuName = "Game/Data/Troll")]
public class TrollSo : ScriptableObject
{
    [SerializeField] public float velocityX = 10;
    [SerializeField] public float enemyHealth = 70;

    [SerializeField] public float attackDamage = 15;
    [SerializeField] public float flashTime = 0.3f;
}
