using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatText : MonoBehaviour
{
    Animator anim;

    public bool IsInCombat {get; set;}

    void Awake()
    {
        anim = GetComponent<Animator>();    
    }

    public void Show()
    {
        if(IsInCombat) return;
        anim.SetTrigger("show");
    }
}
