using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvt : MonoBehaviour
{
    Vector3 originalpos;
    public float speed;
    public bool begin;
    
    // Start is called before the first frame update
    void Start()
    {
        begin = true;
        originalpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(begin){
            speed += Time.deltaTime/5f;
        }
        
        transform.Translate(0,0,-speed *Time.deltaTime);
        if(transform.position.z< 50){
            transform.position = originalpos;
        }
        
    }
}
