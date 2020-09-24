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

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = actionAreaColor;

        //Gizmos.DrawWireSphere(transform.position, actionAreaRadius);
        UnityEditor.Handles.color = actionAreaColor;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, actionAreaRadius);
    }

    protected bool ActionAreaCollider => Physics.OverlapSphere(transform.position, actionAreaRadius, layerDetection).Length > 0;
}
