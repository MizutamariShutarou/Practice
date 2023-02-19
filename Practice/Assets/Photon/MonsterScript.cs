using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 0.05f;
        }
        else
        {
            Debug.Log("‚“‚“‚“");
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 10, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -10, 0);
        }
    }
}
