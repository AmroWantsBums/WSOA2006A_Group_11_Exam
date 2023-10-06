using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float RayLength;
    public GameObject TameTxt;
    public Rigidbody Rb;
    public float JumpHeight;
    public bool IsGrounded = true;

    void Start()
    {
        Cursor.visible = false;
        Rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0.0f, mouseX * rotationSpeed, 0.0f);
        transform.Rotate(rotation);

        RaycastHit Hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayLength, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, RayLength))
        {
            if (Hit.transform.gameObject.CompareTag("Animal"))
            {
                TameTxt.SetActive(true);
                if (Input.GetKeyDown("space"))
                {
                    //Activate ability 
                }
            }
        }
        else
        {
            TameTxt.SetActive(false);
        }

        if (Input.GetKeyDown("space") && IsGrounded)
        {
            Rb.AddForce(transform.up * JumpHeight, ForceMode.Impulse);
            IsGrounded = false; 
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}