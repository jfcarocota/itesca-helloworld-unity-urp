using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : NPC
{

    NavMeshAgent navMeshAgent;

    new void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
            if(!GameManager.instance.GetCombat.IsInCombat)
            {
                GameManager.instance.GetCombat.Show();
                GameManager.instance.GetCombatPanel.Show();
                GameManager.instance.GetCombat.IsInCombat = true;
            }
            //base.MoveForward();
            navMeshAgent.SetDestination(GameManager.instance.PlayerTransform.position);
            //transform.LookAt(GameManager.instance.PlayerTransform);
            //Debug.Log(navMeshAgent.destination);
        }
        else
        {
            navMeshAgent.SetDestination(transform.position);
            if(GameManager.instance.GetCombat.IsInCombat)
            {
                GameManager.instance.GetCombat.IsInCombat = false;
                GameManager.instance.GetCombatPanel.Hide();
                GameManager.instance.ResetBGAudio();
            }
        }
    }
}
