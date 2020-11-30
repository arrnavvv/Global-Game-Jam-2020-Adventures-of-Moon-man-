using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class uranusPlayer : MonoBehaviour
{
    public GameObject levelLostCanvas;
    public GameObject levelWonCanvas;
    private int health = 3;
    public GameObject heart1, heart2,heart3;
    bool hasKey = false;
    public Animator gemAnim;
    public GameObject m1, m2, m3, m4, m5, m6, m7;
    public TMP_Text timerText;
    public Text info;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public GameObject explosionSound;
    public GameObject doorSound;
    public GameObject particleEffect;
    public GameObject gemBreakEffect;
    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        Timer();
        timerText.text = timeRemaining.ToString("0");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("urMonster"))
        {
            Instantiate(particleEffect, collision.gameObject.transform.position, Quaternion.identity);
            Instantiate(explosionSound);
            health--;
            if (health == 2)
                heart3.SetActive(false);
            else if (health == 1)
                heart2.SetActive(false);
            else if (health == 0)
            {
                heart1.SetActive(false);
               levelLostCanvas.SetActive(true);
                 GetComponent<movementController>().enabled = false;
            }
        }

        else if (collision.gameObject.CompareTag("destroyer"))
        {
            Instantiate(gemBreakEffect, collision.gameObject.transform.position, Quaternion.identity);
            Instantiate(particleEffect, m7.transform.position, Quaternion.identity);
            Destroy(m1); Destroy(m2); Destroy(m3); Destroy(m4); Destroy(m5); Destroy(m6); Destroy(m7);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("key"))
        {
            
            hasKey = true;
            gemAnim.SetBool("haskey", true);
            
        }

        if (collision.gameObject.CompareTag("door")&& hasKey)
        {
            Instantiate(doorSound);
            levelWonCanvas.SetActive(true);
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
                levelLostCanvas.SetActive(true);
                GetComponent<movementController>().enabled = false;
            }
        }
    }
}
