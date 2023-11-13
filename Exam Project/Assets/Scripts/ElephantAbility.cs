using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantAbility : MonoBehaviour
{
    public float RayLength;
    public GameObject PullLeverText;
    public PlayerController playerController;
    public bool LeverPulled = false;
    public float speed;
    public GameObject GateObject;
    public GameObject PositionToMoveTo;
    public UI uiscript;
    public Animator anim;
    public bool AnimPlayed = false;

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
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayLength, Color.green);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, RayLength))
            {
                if (hit.transform.gameObject.CompareTag("Lever"))
                {
                    PullLeverText.SetActive(true);

                    if (Input.GetKeyDown("f"))
                    {
                        LeverPulled = true;
                        PullLeverText.SetActive(false);
                    }
                }
            }            
        }
        if (LeverPulled)
        {
            PullLever(GateObject);
            playerController.ElephantAbilityActive = false;
            StartCoroutine(ResetAnimation());
        }
    }


    void PullLever(GameObject Gate)
    {
        if (!AnimPlayed)
        {
            anim.SetBool("PullLever", true);
            AnimPlayed = true;
        }
        float step = speed * Time.deltaTime;
        float distance = Vector3.Distance(Gate.transform.position, PositionToMoveTo.transform.position);
        Gate.transform.position = Vector3.MoveTowards(Gate.transform.position, PositionToMoveTo.transform.position, Mathf.Min(step, distance));
        uiscript.Reset();
    }

    IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("PullLever", false);
    }
}
