using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineScript : MonoBehaviour
{
    Animator anim;

    public bool jumpSuccess;
    public bool sprintSuccess;
    public bool walk;
    public bool grab;

    void Start()
    {
        anim = GetComponent<Animator>();
      
    }

    void Update()
    {
        if (jumpSuccess)
        {
            anim.SetBool("Jump", true);
            jumpSuccess = false;
        }

        if(sprintSuccess)
        {
            anim.SetBool("Sprint", true);
        }

        if(walk)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(grab)
        {
            anim.SetBool("Grab", true);
        }
    }
}
