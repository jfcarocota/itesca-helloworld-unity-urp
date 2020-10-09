using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField, Range(0.1f, 100f)]
    float damange;

    [SerializeField]
    Attack attack;

    public float GetDamage => damange;

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemy"))
        {
            if(attack.IsAttaking)
            {
                Debug.Log("hit");
                attack.IsAttaking = false;
            }
        }
    }
}
