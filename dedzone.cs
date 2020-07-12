using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dedzone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("coin")){
            Destroy(other.gameObject);
        }else if(other.CompareTag("obs")){
            Destroy(other.gameObject);
        }else if(other.CompareTag("obstacle")){
            Destroy(other.gameObject);
        }
    }
}
