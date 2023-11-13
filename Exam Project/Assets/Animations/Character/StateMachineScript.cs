using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineScript : MonoBehaviour
{
    public Animator anim;

    public bool jump;
    public bool sprintSuccess;
    public bool walk;
    public bool grab;
    public bool idle;
    public bool climb;

    void Start()
    {
        
      
    }

    void Update()
    {
        if(climb)
        {
            anim.SetBool("Climb", true);
        }
        else
        {
            anim.SetBool("Climb", false);
        }
        if (jump)
        {
            anim.SetBool("Jump", true);
          
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        if(sprintSuccess)
        {
            anim.SetBool("Sprint", true);
        }
        else
        {
            anim.SetBool("Sprint", false);
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

        if(idle)
        {
            anim.SetBool("Idle", true);
        }
    }
}
