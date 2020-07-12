using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinmvt : MonoBehaviour
{
    Rigidbody rb;
    mvt m;
    playermvt pm;
    AudioSource coinsound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m = GameObject.FindWithTag("floor").GetComponent<mvt>();
        pm = GameObject.FindWithTag("Player").GetComponent<playermvt>();
        coinsound = GameObject.FindWithTag("coinsound").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.up * -m.speed/2f * Time.deltaTime);
        //transform.Rotate(0,5f,0);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")&& PlayerPrefs.GetInt("HasStarted") == 1){
            pm.coincount +=1;
            if(PlayerPrefs.GetInt("sound") == 1){
                coinsound.Play();
            }
            Destroy(gameObject);
        }if(other.CompareTag("Player")&& PlayerPrefs.GetInt("HasStarted") == 0){
            Destroy(gameObject);
        }else if(other.CompareTag("obstacle")){
            Destroy(gameObject);
        }else if(other.CompareTag("obs")){
            Destroy(gameObject);
        }
    }
}
