using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPanel : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Show()
    {
        anim.SetBool("show", true);//show no existe bug
    }

    public void Hide()
    {
        anim.SetBool("show", false);
    }
}
