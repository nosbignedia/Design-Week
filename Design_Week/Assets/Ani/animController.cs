using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{

    public Animator anim;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //chance 1 to start button for joy stick stuff later
        if (Input.GetKeyDown("1"))
        {

            anim.SetTrigger("Right");

        }
        //change to punch (only 1 so far)
        if (Input.GetKeyDown("2"))
        {
            anim.SetTrigger("Punch1");

        }

        if (Input.GetKeyDown("3"))
        {
            anim.SetTrigger("Punch2");



        }

        if (Input.GetKeyDown("4"))
        {

            anim.SetTrigger("left");
        }

        if (Input.GetKeyDown("5"))
        {

            anim.SetTrigger("Hit");
        }
    }
}
