using System.Collections;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    
    private bool canAttack = true;
    [SerializeField] PlayerMovement player;
    [SerializeField] GameObject slashHitBox;
    [SerializeField] private Animator animato;
    [SerializeField] private AudioSource attackSFX;
    void Start()
    {
        canAttack = true;
    }
    private void Update()
    {
        if (Input.GetMouseButton(1) && canAttack) 
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack() 
    {
        canAttack = false;
        player.ChangeIsAttacking();
        animato.Play("Attack");
        attackSFX.Play();
        yield return new WaitForSeconds(0.50f);
        slashHitBox.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        slashHitBox.SetActive(false);
        canAttack = true;
        player.ChangeIsAttacking();
    }
}
