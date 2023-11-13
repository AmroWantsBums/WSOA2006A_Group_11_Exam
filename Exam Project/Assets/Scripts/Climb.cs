using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    public PlayerController playerController;
    public bool Climbing = false;
    public float moveSpeed;
    public Rigidbody PlayerRb;
    public float RayLength;
    public float RayOffset;
    public Vector3 RaySpawnPoint;
    public UI uiscript;
    public Animator anim;
    public StateMachineScript sms;
 

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaySpawnPoint = transform.position + new Vector3(0f, RayOffset, 0f);
        RaycastHit Hit;
        Debug.DrawRay(RaySpawnPoint, transform.TransformDirection(Vector3.forward) * RayLength, Color.blue);
        if (playerController.LeopardAbilityActive)
        {
            if (Physics.Raycast(RaySpawnPoint, transform.TransformDirection(Vector3.forward), out Hit, RayLength))
            {
                if (Hit.transform.gameObject.CompareTag("Climbable"))
                {
                    Climbing = true;
                    Debug.Log("Climb");
                    RayOffset = -0.49f;
                }
            }
            else
            {
                Debug.Log("No ClimbThing");
                Climbing = false;                
            }
        }        

        if (Climbing)
        {
            anim.SetBool("IsClimbing", true);
            playerController.enabled = false;
            sms.climb = true;
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0.0f, verticalInput, 0.0f) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
            PlayerRb.useGravity = false;
            PlayerRb.mass = 0f;
            PlayerRb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            playerController.enabled = true;
            PlayerRb.useGravity = true;
            PlayerRb.mass = 1f;
            
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Climbable"))
        {
            Climbing = false;
            playerController.LeopardAbilityActive = false;
            uiscript.Reset();
            anim.SetBool("IsClimbing", false);
        }
    }
}
