using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVisuals : MonoBehaviour
{
    [SerializeField]
    PlayerAttacks playerAttacks;
    [SerializeField]
    PlayerData playerData;
    Animator animator;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAttacks.OnLightAttack += PlayerAttacks_OnLightAttack;
        playerAttacks.OnHeavyAttack += PlayerAttacks_OnHeavyAttack;
        playerData.OnHealthChange += PlayerData_OnHealthChange;
    }

    private void PlayerData_OnHealthChange(object sender, PlayerData.OnHealthChangeEventArgs e)
    {
        if(e.health <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }

    private void PlayerAttacks_OnHeavyAttack(object sender, System.EventArgs e)
    {
        animator.SetTrigger("isHeavyAttack");
        Debug.Log("Animbegin");
    }

    private void PlayerAttacks_OnLightAttack(object sender, System.EventArgs e)
    {
        animator.SetTrigger("isLightAttack");
    }
}
