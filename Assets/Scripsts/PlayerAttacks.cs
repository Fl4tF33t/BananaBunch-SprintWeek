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
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Debug.Log("small attack");
            OnAttack?.Invoke(this, new OnAttackEventArgs
            {
                damageAttack = 1
            });
            //other.GetComponent<BossData>().HealthDamaged(1);
        }
    }
}
