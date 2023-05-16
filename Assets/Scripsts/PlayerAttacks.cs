using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttacks : MonoBehaviour
{
    public event EventHandler<OnAttackEventArgs> OnAttack;
    public class OnAttackEventArgs : EventArgs
    {
        public int damageAttack;
    }

    public event EventHandler OnLightAttack;
    public event EventHandler OnHeavyAttack;
    public event EventHandler OnSpecialAttack;


    //AttackNumbers
    [SerializeField]
    int lightAttack = 5;
    [SerializeField]
    int heavyAttack = 15;
    [SerializeField]
    int specialAttack = 15;

    [SerializeField]
    private KeyCode key;
    bool canAttack = false;

    private void OnTriggerEnter(Collider other)
    {
        canAttack = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canAttack = false;
    }

    private void Update()
    {
        AttackControls();
    }

    private void AttackControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLightAttack?.Invoke(this, EventArgs.Empty);
            if (canAttack)
            {
                Debug.Log("small attack");
                OnAttack?.Invoke(this, new OnAttackEventArgs
                {
                    damageAttack = lightAttack
                });
            } 
        }
        if (Input.GetMouseButtonDown(1))
        {
            OnHeavyAttack?.Invoke(this, EventArgs.Empty);
            if (canAttack)
            {
                Debug.Log("heavy attack");
                OnAttack?.Invoke(this, new OnAttackEventArgs
                {
                    damageAttack = heavyAttack
                });
            }
        }
        if (Input.GetKeyDown(key))
        {
            OnSpecialAttack?.Invoke(this, EventArgs.Empty);
            if (canAttack)
            {
                Debug.Log("small attack");
                OnAttack?.Invoke(this, new OnAttackEventArgs
                {
                    damageAttack = specialAttack
                });
            }
        }
    }
}
