using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    mvt m;
    //GameObject floor;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.FindWithTag("floor").GetComponent<mvt>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * -m.speed/2f * Time.deltaTime);
    }
}
