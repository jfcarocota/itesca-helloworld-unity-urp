using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 2f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement 3d
        Movement();
        anim.SetFloat("movement", Mathf.Abs(Axis.magnitude));
    }

    void Movement()
    {
        transform.Translate( Axis * Time.deltaTime * moveSpeed);
    }

    Vector3 Axis => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
}
