using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablecoin : MonoBehaviour
{
    public GameObject[] coins;
    int go;
    // Start is called before the first frame update
    void Start()
    {
        go = Random.Range(0,1);
        if(go == 0){
            for (int i = 0; i<coins.Length; ++i){
                coins[i].SetActive(true);
            }
        }else if(go == 1){
            for (int i = 0; i<coins.Length; ++i){
                coins[i].SetActive(false);
            }
        }
    }
}
