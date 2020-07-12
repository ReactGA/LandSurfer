using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermvt : MonoBehaviour
{
    Vector3 startpos,endpos;
    public Rigidbody rb;
    public float xspeed,yspeed,scale;
    public float xupspeed;
    public Transform leftpt,rightpt,middlpt;
    bool isgrounded;
    public GameObject floor;
    GameObject[] obs;
    //public UI ui;
    public GameObject Restartui,Gamui;
    [HideInInspector]public int coincount,scorecount;
    public Text cointext,scoretext;
    public mvt m;
    float i;

    

    private void FixedUpdate() {
        obs = GameObject.FindGameObjectsWithTag("obstacle");
        
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
                startpos = Input.GetTouch(0).position;
            }else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
                endpos = Input.GetTouch(0).position;
            if(startpos.x>endpos.x && Mathf.Abs(startpos.y-endpos.y)<60f){
                rb.AddForce(transform.position + transform.up* xupspeed * Time.deltaTime);
                rb.MovePosition(transform.position + transform.right* -xspeed * Time.deltaTime);
            }else if(startpos.x < endpos.x  && Mathf.Abs(startpos.y-endpos.y)<60f ){
                rb.AddForce(transform.position + transform.up* xupspeed * Time.deltaTime);
                rb.MovePosition(transform.position + transform.right* xspeed * Time.deltaTime);
            }
            else if(startpos.y < endpos.y && Mathf.Abs(startpos.x-endpos.x)< 60f && isgrounded){
            //jump
                rb.AddForce(transform.position + transform.up* yspeed * Time.deltaTime);
            }else if(startpos.y > endpos.y && Mathf.Abs(startpos.x-endpos.x)<60f){
                transform.localScale = new Vector3(1f,scale,1f);
                Invoke("rtn",1.5f);
            }
        }

        i += Time.deltaTime/3;
        scorecount = (int)i;
        
        cointext.text = coincount.ToString("0");
        scoretext.text = scorecount.ToString("0");
        if(Input.GetMouseButtonDown(0)){
            startpos = Input.mousePosition;
        }else if(Input.GetMouseButtonUp(0)){
            endpos = Input.mousePosition;
            
            if(startpos.x>endpos.x && Mathf.Abs(startpos.y-endpos.y)<60f){
                rb.AddForce(transform.position + transform.up* xupspeed * Time.deltaTime);
                rb.MovePosition(transform.position + transform.right* -xspeed * Time.deltaTime);
            }else if(startpos.x < endpos.x  && Mathf.Abs(startpos.y-endpos.y)<60f ){
                rb.AddForce(transform.position + transform.up* xupspeed * Time.deltaTime);
                rb.MovePosition(transform.position + transform.right* xspeed * Time.deltaTime);
            }
            else if(startpos.y < endpos.y && Mathf.Abs(startpos.x-endpos.x)< 60f && isgrounded){
            //jump
                rb.AddForce(transform.position + transform.up* yspeed * Time.deltaTime);
            }else if(startpos.y > endpos.y && Mathf.Abs(startpos.x-endpos.x)<60f){
                transform.localScale = new Vector3(1f,scale,1f);
                transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,0.7f,transform.position.z),150f*Time.deltaTime);
                Invoke("rtn",1.5f);
            }
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-3f,3f),Mathf.Clamp(transform.position.y,0f,15f),transform.position.z);
        float a= Vector3.Distance(transform.position,leftpt.position);
        float b= Vector3.Distance(transform.position,rightpt.position);
        float c= Vector3.Distance(transform.position,middlpt.position);
        if(a<b && a<c && isgrounded){
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(leftpt.position.x,transform.position.y,transform.position.z),xspeed*Time.deltaTime);
        }else if(b<a && b<c && isgrounded){
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(rightpt.position.x,transform.position.y,transform.position.z),xspeed*Time.deltaTime);
        }else if(c<a && c<b && isgrounded){
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(middlpt.position.x,transform.position.y,transform.position.z),xspeed*Time.deltaTime);
        }

        if(Input.GetKey("z")){
            Debug.Log("coin " + coincount);
            Debug.Log("score " + scorecount);
        }

        /*if(transform.position.y > 4){
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,4f,transform.position.z),150f*Time.deltaTime);
        }/* */

    }

    void rtn(){
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,1.1f,transform.position.z),150f*Time.deltaTime);
        transform.localScale = new Vector3(1f,1f,1f);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("floor")){
            isgrounded = true;
        }else if(other.gameObject.CompareTag("obs") && PlayerPrefs.GetInt("HasStarted") == 1){
            floor.GetComponent<mvt>().begin = false;
            floor.GetComponent<mvt>().speed = 0f;
            Invoke("restart",1f);
        }else if(other.gameObject.CompareTag("obs") && PlayerPrefs.GetInt("HasStarted") == 0){
            floor.GetComponent<mvt>().begin = false;
            floor.GetComponent<mvt>().speed = 0f;
            Invoke("restarttest",1f);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("floor")){
            isgrounded = false;
        }
    }

    void restart(){
        Time.timeScale = 0f;
        Gamui.SetActive(false);
        Restartui.SetActive(true);
    }
    void restarttest(){
        SceneManager.LoadScene(0);
    }

}
