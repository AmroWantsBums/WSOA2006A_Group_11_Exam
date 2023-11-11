using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject BreakWallText;
    public float RayLength;
    public Rigidbody PlayerRb;
    public bool Dashing = false;
    public float DashSpeed;
    public UI uiscript;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        PlayerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.RhinoAbilityActive)
        {
            BreakWallText.SetActive(false);
            RaycastHit Hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayLength, Color.green);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, RayLength))
            {
                if (Hit.transform.gameObject.CompareTag("Breakable"))
                {
                    BreakWallText.SetActive(true);
                }
            }
            if (Input.GetKey("f") && !Dashing)
            {
                PlayerRb.AddForce(transform.forward * DashSpeed, ForceMode.Impulse);
                Dashing = true;                
                StartCoroutine(DashReset());
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Dashing && collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DashReset()
    {
        yield return new WaitForSeconds(1f);
        Dashing = false;
        playerController.RhinoAbilityActive = false;
        uiscript.Reset();
    }
}
