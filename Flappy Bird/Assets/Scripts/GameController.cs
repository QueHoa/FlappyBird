using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndgame = false;
    public bool isStartgame = false;
    int gamePoint = 0;
    public Text textPoint;
    public Button playSound;
    public Button pauseSound;
    public GameObject panelStart;
    public GameObject panelEnd;
    public GameObject panelPause;
    public Text textScore;
    public AudioClip gameMusicClip;

    private AudioSource audioSource;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isEndgame = false;
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.Play();
        panelStart.SetActive(true);
        panelEnd.SetActive(false);
        panelPause.SetActive(false);    
        playSound.gameObject.SetActive(false);
        pauseSound.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndgame)
        {
            if (Input.GetMouseButton(0) && isStartgame)
            {
                StartGame();
            }          
        }
        else
        {
            if (Input.GetMouseButton(0) && isStartgame)
            {
                PlayGame();
            }
        } 
    }
    void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        isStartgame = true;
        Time.timeScale = 1;
        panelStart.SetActive(false);
    }
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            panelPause.SetActive(true);
            isStartgame = false;
            Time.timeScale = 0;
        }
        else
        {
            panelPause.SetActive(false);
            Time.timeScale = 1;
            isStartgame = true;
        }
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Debug.Log("Exit");
    }
    public void RestartGame()
    {
        StartGame();
    }
    public void GetPoint()
    {
        gamePoint += 1;
        textPoint.text = gamePoint.ToString();
    }
    public void EndGame()
    {
        isStartgame = false;
        audioSource.Pause();
        isEndgame = true;
        Time.timeScale = 0;
        panelEnd.SetActive(true);
        textScore.text = "Score: " + gamePoint.ToString();
    }
    public void PlaySound()
    {
        playSound.gameObject.SetActive(false);
        pauseSound.gameObject.SetActive(true);
        audioSource.Play();
    }
    public void PauseSound()
    {
        playSound.gameObject.SetActive(true);
        pauseSound.gameObject.SetActive(false);
        audioSource.Pause();
    }
}
