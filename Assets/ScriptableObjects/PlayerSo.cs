using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Data/Player")]
public class PlayerSo : ScriptableObject
{
    // Warning: Todos los campos del SO son [SerializeField] public, cualquier clase puede modificar el asset en runtime.
    // Dejalos [SerializeField] private y exponé properties de solo lectura (public float Speed => speed;).
    [SerializeField] public LayerMask floorLayer;
    [SerializeField] public float coyoteTime = 0.15f;
    [SerializeField] public float bufferTime = 0.25f;
    [SerializeField] public float speed = 5;
    [SerializeField] public float jumpForce = 7;
    [SerializeField] public float originalGravityScale = 2.5f;
    [SerializeField] public float jumpGravityScale = 1;
    [SerializeField] public float rayCastLong = 1.2f;
    [SerializeField] public float slashDamage = 20;

    [SerializeField] public float contactDamage = 20;
    // Suggestion: 'invulneravilityTime' tiene un error de tipeo (invulnerability) y 'Life' rompe el camelCase del resto.
    // Además contactDamage e invulneravilityTime se leen en PlayerHealth pero nunca se usan.
    [SerializeField] public float invulneravilityTime = 1.7f;
    [SerializeField] public float Life = 100;


}
