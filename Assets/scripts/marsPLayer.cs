using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class marsPLayer : MonoBehaviour
{
    bool hasKey = false;
    public Text timerText;
    public Text info;
    public float timeRemaining = 50;
    public bool timerIsRunning = false;
    public GameObject LevelWonPanel;
    public GameObject LevelLostPanel;
    public float timeLeftForInfo = 3;
    public bool timeRunningInfo = false;
    public GameObject doorCloseSound;
    public GameObject keySound;

    

    void Start()
    {
        GetComponent<movementController>().enabled = false;
        timeRunningInfo = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerForInstruction();
        Timer();
        timerText.text =   timeRemaining.ToString("0");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            hasKey = true;
            Instantiate(keySound, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("door"))
        {
            if (hasKey)
            {
                Instantiate(doorCloseSound);
                LevelWonPanel.SetActive(true);
                Destroy(gameObject);
            }
        }
        if (other.gameObject.CompareTag("lava"))
        {
            timerIsRunning = false;
            GetComponent<movementController>().enabled = false;
            LevelLostPanel.SetActive(true);
        }
    }

    void Timer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void TimerForInstruction()
    {
        if (timeRunningInfo)
        {
            if (timeLeftForInfo > 0)
            {
                timeLeftForInfo -= Time.deltaTime;
            }
            else
            {
                info.enabled = false;
                GetComponent<movementController>().enabled = true;
                timerIsRunning = true;
                timeLeftForInfo = 0;
                timeRunningInfo = false;
            }
        }
    }

   public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
