using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class earthPlayer : MonoBehaviour
{
    /*public GameObject[] enemyDown;
    public GameObject enemyRight;
    public GameObject enemyLeft;

    public float downY;
    public Vector2 downRespawnPos;*/

    public GameObject[] enemies;

    public GameObject levelLostPanel;
    public GameObject levelWonPanel;
    public float timeRemaining = 4;
    public bool timerIsRunning = true;
    public Text timeText;
    public GameObject explosionSound;
    
    public Text info;
    void Start()
    {
        
    }

    void Update()
    {
        timeText.text = timeRemaining.ToString("0");
        Timer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemyDown") || collision.gameObject.CompareTag("enemyLeft")||collision.gameObject.CompareTag("enemyRight"))
        {
            Instantiate(explosionSound);
            timerIsRunning = false;
            levelLostPanel.SetActive(true);
            GetComponent<movementController>().enabled = false;
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
                for(int i = 0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i]);
                }

                levelWonPanel.SetActive(true);
                
            }
        }
    }
}
