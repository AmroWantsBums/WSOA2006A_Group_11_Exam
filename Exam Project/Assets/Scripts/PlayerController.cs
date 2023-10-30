using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float RayLength;
    public GameObject ViewPaintingTxt;
    public Rigidbody Rb;
    public float JumpHeight;
    public bool IsGrounded = true;
    public PaintingState paintingState;
    public bool CanView = false;
    public bool IsViewing = false;
    public GameObject GetAbilityTxt;
    public DialogueManager dialogueManager;
    public GameObject DialogueAvailableTxt;
    public bool CanViewDialogue = false;
    //Ability bools
    public bool HasLionAbility = false;
    public bool LionAbilityActive = false;
    public bool HasBuffaloAbility = false;
    public bool BuffaloAbilityActive = false;
    public bool HasRhinoAbility = false;
    public bool RhinoAbilityActive = false;

    //Animation Code:
    public StateMachineScript sms;


    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        Cursor.visible = false;
        Rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        paintingState = GameObject.Find("Canvas").GetComponent<PaintingState>();

        //Call State Machine Script
        sms = GetComponent<StateMachineScript>();
    }
    void Update()
    {

        if (Input.GetKeyDown("space") && IsGrounded)
        {
            Debug.Log("Jump");
            Rb.AddForce(transform.up * JumpHeight, ForceMode.Impulse);
            //play jump animation
            //sms.jumpSuccess = true;
            if (LionAbilityActive)
            {
                Rb.AddForce(transform.forward * 8, ForceMode.Impulse);
                LionAbilityActive = false;
            }

            IsGrounded = false;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0.0f, mouseX * rotationSpeed, 0.0f);
        transform.Rotate(rotation);
        DialogueAvailableTxt.SetActive(false);



        RaycastHit Hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayLength, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, RayLength))
        {
            if (Hit.transform.gameObject.CompareTag("NPC") && !CanViewDialogue)
            {
                DialogueAvailableTxt.SetActive(true);
                if (Input.GetKeyDown("f"))
                {
                    Debug.Log("Testsdfd");
                    DialogueAvailableTxt.SetActive(false);
                    CanViewDialogue = true;
                }
            }
            if (Hit.transform.gameObject.CompareTag("Animal"))
            {
                CanView = true;
                if (Input.GetKeyDown("f") && Hit.transform.gameObject.name == "LionWallPainting")
                {
                    HasLionAbility = true;
                }
                if (Input.GetKeyDown("f") && Hit.transform.gameObject.name == "BuffaloWallPainting")
                {
                    HasBuffaloAbility = true;
                }
                if (Input.GetKeyDown("f") && Hit.transform.gameObject.name == "RhinoWallPainting")
                {
                    HasRhinoAbility = true;
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    IsViewing = true;
                }

                if (IsViewing)
                {
                    ViewPaintingTxt.SetActive(false);
                    GetAbilityTxt.SetActive(false);
                }
                else
                {
                    ViewPaintingTxt.SetActive(true);
                    GetAbilityTxt.SetActive(true);
                }
            }
        }
        else
        {
            ViewPaintingTxt.SetActive(false);
            GetAbilityTxt.SetActive(false);
        }

        if (HasLionAbility && Input.GetKeyDown(KeyCode.Alpha1))
        {
            LionAbilityActive = true;
        }

        if (HasBuffaloAbility && Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuffaloAbilityActive = true;
        }

        if (HasRhinoAbility && Input.GetKeyDown(KeyCode.Alpha3))
        {
            RhinoAbilityActive = true;
        }



        if (verticalInput == 0)
        {
            sms.walk = false;
        }
        else
        {
            //play walking animation
            sms.walk = true;
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