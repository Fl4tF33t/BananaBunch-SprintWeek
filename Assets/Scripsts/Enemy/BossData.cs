using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossData : MonoBehaviour
{
    public event EventHandler<OnHealthChangeEventArgs> OnHealthChange;
    public class OnHealthChangeEventArgs : EventArgs
    {
        public int health;
    }
    public int health = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            HealthDamaged(1);
        }
    }

    public int CurrentHealth()
    {
        return health;
    }

    private void HealthDamaged(int damage)
    {
        health -= damage;

        OnHealthChange?.Invoke(this, new OnHealthChangeEventArgs
        {
            health = CurrentHealth()
        }); ;
    }
}
