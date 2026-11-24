using System.Collections;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    
    private bool canAttack = true;
    [SerializeField] PlayerMovement player;
    [SerializeField] GameObject slashHitBox;
    // Suggestion: 'animato' es un nombre truncado, usá animator.
    [SerializeField] private Animator animato;
    [SerializeField] private AudioSource attackSFX;
    void Start()
    {
        canAttack = true;
    }
    private void Update()
    {
        // Bug: Update no considera la pausa. Con Time.timeScale = 0 (pausa o game over) el clic derecho igual arranca Attack(),
        // reproduce attackSFX y la animación queda colgada. Chequeá Time.timeScale o deshabilitá el componente al pausar.
        if (Input.GetMouseButton(1) && canAttack) 
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack() 
    {
        canAttack = false;
        // Suggestion: ChangeIsAttacking() alterna el estado en vez de setearlo. Si una llamada se pierde, queda invertido.
        // Usá SetAttacking(true) / SetAttacking(false).
        player.ChangeIsAttacking();
        animato.Play("Attack");
        attackSFX.Play();
        // Suggestion: Tiempos 0.50f y 0.25f mágicos, llevalos a PlayerSo.
        yield return new WaitForSeconds(0.50f);
        slashHitBox.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        slashHitBox.SetActive(false);
        canAttack = true;
        player.ChangeIsAttacking();
    }
}
