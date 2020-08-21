using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMesh;

    [SerializeField]
    float moveSpeed = 2f;

    Animator anim;

    int score;

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
        anim.SetFloat("movement", AxisMagnitudeAbs);
    }

    void Movement()
    {
        if(IsMoving)
        {
            transform.Translate( Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.LookRotation(Axis.normalized);
        }
    }

    /// <summary>
    /// Retunrs the axis with H input and V Input.
    /// </summary>
    /// <returns></returns>
    Vector3 Axis => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

    /// <summary>
    /// Check if player is moving with inputs H and V.
    /// </summary>
    bool IsMoving => AxisMagnitudeAbs > 0;

    /// <summary>
    /// Returns the magnitude of the Axis with inputs H and V.
    /// </summary>
    /// <returns></returns>
    float AxisMagnitudeAbs => Mathf.Abs(Axis.magnitude);

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Collectable"))
        {
            score++;
            textMesh.text = $"Score: {score}";
            Destroy(other.gameObject);
        }   
    }
}
