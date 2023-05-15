using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stinger : MonoBehaviour
{
    Rigidbody stingerRB;

    private void Start()
    {
        stingerRB = GetComponent<Rigidbody>();
    }
    public void StingerShot(Vector3 direction)
    {
        stingerRB.AddForce(direction);
    }
}
