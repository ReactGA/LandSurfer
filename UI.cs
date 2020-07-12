using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject StartUi,GameUi,restartui,pauseui,themeui,wall1,wall2;
    
    void Awake()
    {
        if(PlayerPrefs.GetInt("HasStarted") == 1){
        StartUi.SetActive(false);
        GameUi.SetActive(true);
        Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("sound") == 0){
            themeui.SetActive(false);
        }else if(PlayerPrefs.GetInt("sound") == 1){
           themeui.SetActive(true);
        }
        if(PlayerPrefs.GetInt("wall") == 0){
            wall1.SetActive(false);
            wall2.SetActive(false);
        }else if(PlayerPrefs.GetInt("wall") == 1){
           wall1.SetActive(true);
            wall2.SetActive(true);
        }
        
    }

    public void Startgame(){
        StartUi.SetActive(false);
        GameUi.SetActive(true);
        PlayerPrefs.SetInt("HasStarted",1);
        SceneManager.LoadScene(0);

    }

    public void Quit(){
        PlayerPrefs.SetInt("HasStarted",0);
        Application.Quit();
    }

    public void restart(){
        PlayerPrefs.SetInt("HasStarted",1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void resume(){
        Time.timeScale = 1f;
        GameUi.SetActive(true);
        pauseui.SetActive(false);
    }
    public void pause(){
        Time.timeScale = 0f;
        GameUi.SetActive(false);
        pauseui.SetActive(true);
    }
    public void menu(){
        pauseui.SetActive(false);
        restartui.SetActive(false);
        PlayerPrefs.SetInt("HasStarted",0);
        Time.timeScale = 1f;
        //StartUi.SetActive(true);
        SceneManager.LoadScene(0);
    }
    
    public void sounds(){
        if(PlayerPrefs.GetInt("sound") == 0){
            PlayerPrefs.SetInt("sound",1);
        }else if(PlayerPrefs.GetInt("sound") == 1){
            PlayerPrefs.SetInt("sound",0);
        }
    }
    public void wall(){
        if(PlayerPrefs.GetInt("wall") == 0){
            PlayerPrefs.SetInt("wall",1);
        }else if(PlayerPrefs.GetInt("wall") == 1){
            PlayerPrefs.SetInt("wall",0);
        }
    }
    
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("HasStarted",0);
    }
}
