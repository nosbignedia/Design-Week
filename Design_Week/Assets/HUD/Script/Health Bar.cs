using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float hp_p1 = 100f;
    public float hp_p2 = 100f;

    public float sp_p1 = 100f;
    public float sp_p2 = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            hp_p2 -= 5;
            sp_p1 -= 5;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            hp_p1 -= 5;
            sp_p2 -= 5;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            hp_p2 -= 5;
            sp_p1 -= 5;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            hp_p1 -= 5;
            sp_p2 -= 5;
        }

    }
}
