using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : NPC
{
    enum Direction{RIGHT, LEFT};

    [SerializeField]
    Direction direction;
    [SerializeField, Range(0.1f, 10f)]
    float delay = 3f;
    float timer;

    [SerializeField, Range(0.1f, 10f)]
    float waitingDelay = 5f; 

    bool isWating = false;

    bool isTalking = false;


     void Start()
    {
        SwapRotation();
        anim.SetBool("walk", true);    
    }

    void Update()
    {
        if(isTalking) return;
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

    void FixedUpdate()
    {
        MoveForward();    
    }

    protected override void MoveForward()
    {

        if(ActionAreaCollider)
        {
            //base.MoveForward();
            isTalking = true;
            anim.SetBool("walk", false);
            transform.LookAt(GameManager.instance.PlayerTransform);
            GameManager.instance.GetDialogBox.Show();
        }
        else
        {
            GameManager.instance.GetDialogBox.Hide();
            if(!isWating)
            {
                base.MoveForward();
            }
        }
    }
}
