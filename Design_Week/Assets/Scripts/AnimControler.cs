using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControler : MonoBehaviour
{

    public Animator anim;

    // Use this for initialization
    void Start()
    {
       
        anim = GetComponent<Animator>();
        anim.Play("Fighting Idle");
    }

    // Update is called once per frame
    void Update()
    { 
        int Iframes = 0;
        Iframes--;
        //chance 1 to start button for joy stick stuff later
        if (Input.GetKeyDown("1"))
        {
            Iframes = +9;
            anim.Play("Dodge Right");

        }
        //change to punch 
       if (Input.GetKeyDown("2"))
        {
            Iframes += 9;
            anim.Play("Boxing");
        }

       //should be default
        if(Iframes >= 0)
        {
            anim.Play("Fighting Idle");
        }
    }
}
