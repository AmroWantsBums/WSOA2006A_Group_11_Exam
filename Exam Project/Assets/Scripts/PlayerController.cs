using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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
    public GameObject AbilityGFX;
    public RawImage Painting;
    public Texture LionPainting;
    public Texture RhinoPainting;
    public Texture BuffalPainting;
    public Texture LeopardPainting;
    public Texture ElephantPainting;
    //Ability bools
    public bool HasLionAbility = false;
    public bool LionAbilityActive = false;
    public bool HasBuffaloAbility = false;
    public bool BuffaloAbilityActive = false;
    public bool HasRhinoAbility = false;
    public bool RhinoAbilityActive = false;
    public bool HasElephantAbility = false;
    public bool ElephantAbilityActive = false;
    public bool HasLeopardAbility = false;
    public bool LeopardAbilityActive = false;

    //Animation Code:
    public StateMachineScript sms;
    public UI uiscript;


    //Vide Code
    public VideoPlayer LionVideo;
    public VideoPlayer RhinoVideo;
    public VideoPlayer BuffaloVideo;
    public VideoPlayer LeopardVideo;
    public VideoPlayer ElephantVideo;
    public GameObject LionVideoObject;
    public GameObject RhinoVideoObject;
    public GameObject BuffaloVideoObject;
    public GameObject LeopardVideoObject;
    public GameObject ElephantVideoObject;
    public RawImage LionImage;
    public RawImage RhinoImage;
    public RawImage BuffaloImage;
    public RawImage LeopardImage;
    public RawImage ElephantImage;


    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        Cursor.visible = false;
        Rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        paintingState = GameObject.Find("Canvas").GetComponent<PaintingState>();
        RhinoVideo.loopPointReached += OnVideoEnd;
        BuffaloVideo.loopPointReached += OnVideoEnd;
        LeopardVideo.loopPointReached += OnVideoEnd;
        ElephantVideo.loopPointReached += OnVideoEnd;
        LionVideo.loopPointReached += OnVideoEnd;
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
                uiscript.Reset();
            }

            IsGrounded = false;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey("left shift"))
        {
            Debug.Log("Sprinting");
            moveSpeed = 12f;
        }
        else
        {
            moveSpeed = 8f;
        }
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
                    Instantiate(AbilityGFX, transform.position, Quaternion.identity);
                    StartCoroutine(PlayLionVideo());
                }
                if (Input.GetKeyDown("f") && Hit.transform.gameObject.name == "BuffaloWallPainting")
                {
                    HasBuffaloAbility = true;
                    Instantiate(AbilityGFX, transform.position, Quaternion.identity);
                    StartCoroutine(PlayBuffaloVideo());
                }
                if (Input.GetKeyDown("f") && Hit.transform.gameObject.name == "RhinoWallPainting")
                {
                    HasRhinoAbility = true;
                    Instantiate(AbilityGFX, transform.position, Quaternion.identity);
                    StartCoroutine(PlayRhinoVideo());
                }
                if (Input.GetKeyDown("f") && Hit.transform.gameObject.name == "LeopardWallPainting")
                {
                    HasLeopardAbility = true;
                    Instantiate(AbilityGFX, transform.position, Quaternion.identity);
                    StartCoroutine(PlayLeopardVideo());
                }
                if (Input.GetKeyDown("f") && Hit.transform.gameObject.name == "ElephantWallPainting")
                {
                    HasElephantAbility = true;
                    Instantiate(AbilityGFX, transform.position, Quaternion.identity);
                    StartCoroutine(PlayElephantVideo());
                }

                if (Input.GetKeyDown(KeyCode.LeftShift) && Hit.transform.gameObject.name == "LionWallPainting")
                {
                    if (!IsViewing)
                    {
                        IsViewing = true;
                        Painting.texture = LionPainting;
                    }
                    else
                    {
                        IsViewing = false;
                    }
                }


                if (Input.GetKeyDown(KeyCode.LeftShift) && Hit.transform.gameObject.name == "RhinoWallPainting")
                {
                    if (!IsViewing)
                    {
                        IsViewing = true;
                        Painting.texture = RhinoPainting;
                    }
                    else
                    {
                        IsViewing = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftShift) && Hit.transform.gameObject.name == "BuffaloWallPainting")
                {
                    if (!IsViewing)
                    {
                        IsViewing = true;
                        Painting.texture = BuffalPainting;
                    }
                    else
                    {
                        IsViewing = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftShift) && Hit.transform.gameObject.name == "LeopardWallPainting")
                {
                    if (!IsViewing)
                    {
                        IsViewing = true;
                        Painting.texture = LeopardPainting;
                    }
                    else
                    {
                        IsViewing = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftShift) && Hit.transform.gameObject.name == "ElephantWallPainting")
                {
                    if (!IsViewing)
                    {
                        IsViewing = true;
                        Painting.texture = ElephantPainting;
                    }
                    else
                    {
                        IsViewing = false;
                    }
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
            BuffaloAbilityActive = false;
            RhinoAbilityActive = false;
            LeopardAbilityActive = false;
            ElephantAbilityActive = false;
        }

        if (HasBuffaloAbility && Input.GetKeyDown(KeyCode.Alpha2))
        {
            LionAbilityActive = false;
            BuffaloAbilityActive = true;
            RhinoAbilityActive = false;
            LeopardAbilityActive = false;
            ElephantAbilityActive = false; 
        }

        if (HasRhinoAbility && Input.GetKeyDown(KeyCode.Alpha4))
        {
            LionAbilityActive = false;
            BuffaloAbilityActive = false;
            RhinoAbilityActive = true;
            LeopardAbilityActive = false;
            ElephantAbilityActive = false;
        }

        if (HasLeopardAbility && Input.GetKeyDown(KeyCode.Alpha3))
        {
            LionAbilityActive = false;
            BuffaloAbilityActive = false;
            RhinoAbilityActive = false;
            LeopardAbilityActive = true;
            ElephantAbilityActive = false;
        }

        if (HasElephantAbility && Input.GetKeyDown(KeyCode.Alpha5))
        {
            LionAbilityActive = false;
            BuffaloAbilityActive = false;
            RhinoAbilityActive = false;
            LeopardAbilityActive = false;
            ElephantAbilityActive = true;
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
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Liftable"))
        {
            IsGrounded = true;
        }
    }

    IEnumerator PlayLionVideo()
    {
        yield return new WaitForSeconds(2f);
        LionImage.enabled = true;
        LionVideoObject.SetActive(true);
        LionVideo.Play();
        GameObject[] GFXs = GameObject.FindGameObjectsWithTag("AbilityCircle");
        foreach (GameObject f in GFXs)
        {
            Destroy(f);
        }
    }

    IEnumerator PlayRhinoVideo()
    {
        yield return new WaitForSeconds(2f);
        RhinoImage.enabled = true;
        RhinoVideoObject.SetActive(true);
        RhinoVideo.Play();
        GameObject[] GFXs = GameObject.FindGameObjectsWithTag("AbilityCircle");
        foreach (GameObject f in GFXs)
        {
            Destroy(f);
        }
    }

    IEnumerator PlayBuffaloVideo()
    {
        yield return new WaitForSeconds(2f);
        BuffaloImage.enabled = true;
        BuffaloVideoObject.SetActive(true);
        BuffaloVideo.Play();
        GameObject[] GFXs = GameObject.FindGameObjectsWithTag("AbilityCircle");
        foreach (GameObject f in GFXs)
        {
            Destroy(f);
        }
    }

    IEnumerator PlayLeopardVideo()
    {
        yield return new WaitForSeconds(2f);
        LeopardImage.enabled = true;
        LeopardVideoObject.SetActive(true);
        LeopardVideo.Play();
        GameObject[] GFXs = GameObject.FindGameObjectsWithTag("AbilityCircle");
        foreach (GameObject f in GFXs)
        {
            Destroy(f);
        }
    }

    IEnumerator PlayElephantVideo()
    {
        yield return new WaitForSeconds(2f);
        ElephantImage.enabled = true;
        ElephantVideoObject.SetActive(true);
        ElephantVideo.Play();
        GameObject[] GFXs = GameObject.FindGameObjectsWithTag("AbilityCircle");
        foreach (GameObject f in GFXs)
        {
            Destroy(f);
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        vp.enabled = false;
        RhinoImage.enabled = false;
        BuffaloImage.enabled = false;
        LeopardImage.enabled = false;
        ElephantImage.enabled = false;
        LionImage.enabled = false;
    }
}