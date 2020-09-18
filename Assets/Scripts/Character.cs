using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Character : MonoBehaviour
{
   [SerializeField, Range(0.1f, 10f)]
    protected float moveSpeed = 2f;

    protected Animator anim;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void MoveForward()
    {
        transform.Translate( Vector3.forward * Time.deltaTime * moveSpeed);
    }
}
