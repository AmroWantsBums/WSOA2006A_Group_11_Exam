using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantAbility : MonoBehaviour
{
    public float RayLength;
    public GameObject PullLeverText;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.ElephantAbilityActive)
        {
            PullLeverText.SetActive(false);
            RaycastHit Hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayLength, Color.green);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, RayLength))
            {
                if (Hit.transform.gameObject.CompareTag("Lever"))
                {
                    PullLeverText.SetActive(true);
                    if (Input.GetKeyDown("f"))
                    {
                        PullLever();
                    }
                }
            }
        }
    }

    void PullLever()
    {
        //whatever it needs to do
    }
}
