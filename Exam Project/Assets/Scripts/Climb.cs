using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    public PlayerController playerController;
    public bool Climbing = false;
    public float moveSpeed;
    public Rigidbody PlayerRb;
    public StateMachineScript sms;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Climbing)
        {
            sms.climb = true;
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0.0f, verticalInput, 0.0f) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
            PlayerRb.useGravity = false;
            PlayerRb.mass = 0f;
        }
        else
        {
            sms.climb = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Climbable"))
        {
            Climbing = true;
            playerController.enabled = false;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Climbable"))
        {
            Climbing = false;
            playerController.enabled = true;
            PlayerRb.useGravity = true;
            PlayerRb.mass = 1f;
        }
    }
}
