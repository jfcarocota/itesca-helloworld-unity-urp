using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    [SerializeField, Range(0.1f, 10f)]
    protected float actionAreaRadius = 3f;
    [SerializeField]
    protected Color actionAreaColor = Color.yellow;
    [SerializeField]
    protected LayerMask layerDetection;

    enum Direction{RIGHT, LEFT};

    [SerializeField]
    Direction direction;
    [SerializeField, Range(0.1f, 10f)]
    float delay = 3f;
    float timer;

    [SerializeField, Range(0.1f, 10f)]
    float waitingDelay = 5f; 

    bool isWating = false;

    protected override void MoveForward()
    {
        base.MoveForward();
    }

    void Start()
    {
        SwapRotation();
        anim.SetBool("walk", true);    
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(!isWating)
        {
            MoveForward();
            
            if(timer >= delay)
            {
                anim.SetBool("walk", false);
                SwapSate();
            } 
        }
        else
        {
            if(timer >= waitingDelay)
            {
                anim.SetBool("walk", true);
                direction = direction == Direction.RIGHT ? Direction.LEFT : Direction.RIGHT;
                SwapSate();
            } 
        }   
    }

    void SwapSate()
    {
        timer = 0f;
        SwapRotation();
        isWating = !isWating;
    }

    void SwapRotation()
    {
        switch(direction)
        {
            case Direction.RIGHT:
                transform.rotation = Quaternion.LookRotation(Vector3.right);
            break;
            case Direction.LEFT:
                transform.rotation = Quaternion.LookRotation(Vector3.left);
            break;
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = actionAreaColor;

        //Gizmos.DrawWireSphere(transform.position, actionAreaRadius);
        UnityEditor.Handles.color = actionAreaColor;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, actionAreaRadius);
    }

    protected bool ActionAreaCollider => Physics.OverlapSphere(transform.position, actionAreaRadius, layerDetection).Length > 0;
}
