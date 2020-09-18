using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{

    new void Awake()
    {
        base.Awake();
    }
    
    void FixedUpdate()
    {
        anim.SetBool("run", ActionAreaCollider);
        MoveForward();        
    }

    protected override void MoveForward()
    {
        if(ActionAreaCollider)
        {
            base.MoveForward();
            transform.LookAt(GameManager.instance.PlayerTransform);
        }
    }
}
