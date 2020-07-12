using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstspawner : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject coins;
    public Transform L,M,R;
    float stbs,STS,spawntime;
    public float TS,tbs,startspwntime;
    bool spawn;
    
    void Start()
    {
        stbs = tbs;
        STS = TS;
        spawn = true;
        spawntime = startspwntime;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(STS <= 0){
            
            spawn = true
            STS = TS;
        }else{
            spawn = false;
            STS -=Time.deltaTime
        }/* */


        if(spawn){
            #region spawncoin
            int rand = Random.Range(1,7);
            if(stbs <= 0 && rand == 1){
                Instantiate(coins,new Vector3(L.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                stbs = tbs;
            }else if(stbs <= 0 && rand == 2){
                Instantiate(coins,new Vector3(M.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                stbs = tbs;
            }else if(stbs <= 0 && rand == 3){
                Instantiate(coins,new Vector3(R.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                stbs = tbs;
            }else if(stbs <= 0 && rand == 4){
                Instantiate(coins,new Vector3(L.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                Instantiate(coins,new Vector3(M.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                stbs = tbs;
            }else if(stbs <= 0 && rand == 5){
                Instantiate(coins,new Vector3(M.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                Instantiate(coins,new Vector3(R.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                stbs = tbs;
            }else if(stbs <= 0 && rand == 6){
                Instantiate(coins,new Vector3(L.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                Instantiate(coins,new Vector3(R.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                stbs = tbs;
            }else if(stbs <= 0 && rand == 7){
                Instantiate(coins,new Vector3(M.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                Instantiate(coins,new Vector3(R.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                Instantiate(coins,new Vector3(L.position.x,transform.position.y,transform.position.z),Quaternion.Euler(90f,0,0));
                stbs = tbs;
            }else{
                stbs -= Time.deltaTime;
            #endregion
            }
        }
        #region spawn obstacles
        if(spawntime<= 0){
            int j = Random.Range(0,obstacle.Length);
            int k = Random.Range(0,obstacle.Length);
            int r = Random.Range(0,3);
            if(r==0){
                Instantiate(obstacle[j],new Vector3(L.position.x,transform.position.y,transform.position.z),Quaternion.identity);
                Instantiate(obstacle[k],new Vector3(M.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            }else if(r == 1){
                Instantiate(obstacle[j],new Vector3(L.position.x,transform.position.y,transform.position.z),Quaternion.identity);
                Instantiate(obstacle[k],new Vector3(R.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            }else if(r == 2){
                Instantiate(obstacle[j],new Vector3(R.position.x,transform.position.y,transform.position.z),Quaternion.identity);
                Instantiate(obstacle[k],new Vector3(M.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            }else if(r == 3){
                Instantiate(obstacle[j],new Vector3(L.position.x,transform.position.y,transform.position.z),Quaternion.identity);
                Instantiate(obstacle[k],new Vector3(M.position.x,transform.position.y,transform.position.z),Quaternion.identity);
                Instantiate(obstacle[j],new Vector3(R.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            }
            spawntime = startspwntime;
        }else{
            spawntime -= Time.deltaTime;
        }/* */
        #endregion

    }
}
