using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Character
{

    [SerializeField]
    float jumpForce = 5f;

    GameInputs gameInpunts;

    Rigidbody rb;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 10f)]
    float rayDistance = 5;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    Transform rayTransform;

    new void Awake()
    {
        base.Awake();
        gameInpunts = new GameInputs();
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameInpunts.Land.Jump.performed += _=> Jump();
    }

    void Jump()
    {
        if(IsGrounding)
        {
            anim.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnEnable()
    {
        gameInpunts.Enable();
    }

    void OnDisable()
    {
        gameInpunts.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //movement 3d
        MoveForward();
    }

    void LateUpdate()
    {
        anim.SetFloat("movement", AxisMagnitudeAbs);
        anim.SetBool("ground", IsGrounding);
    }

    /// <summary>
    /// Retunrs the axis with H input and V Input.
    /// </summary>
    /// <returns></returns>
    Vector2 Axis => gameInpunts.Land.Move.ReadValue<Vector2>();

    /// <summary>
    /// Check if player is moving with inputs H and V.
    /// </summary>
    bool IsMoving => AxisMagnitudeAbs > 0;

    /// <summary>
    /// Returns the magnitude of the Axis with inputs H and V.
    /// </summary>
    /// <returns></returns>
    float AxisMagnitudeAbs => Mathf.Abs(Axis.magnitude);

    bool IsGrounding => Physics.Raycast(rayTransform.position, -transform.up, rayDistance, groundLayer);

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Collectable"))
        {
            Collectable collectable = other.GetComponent<Collectable>();
            GameManager.instance.GetScore.AddPoints(collectable.Points);
            Destroy(other.gameObject);
        }   
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(rayTransform.position, -transform.up * rayDistance);    
    }

    protected override void MoveForward()
    {
        if(IsMoving)
        {
            base.MoveForward();
            transform.rotation = Quaternion.LookRotation(new Vector3(Axis.x, 0f, Axis.y));
        }
    }
}
