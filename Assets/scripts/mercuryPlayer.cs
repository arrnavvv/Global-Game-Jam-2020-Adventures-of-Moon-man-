using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mercuryPlayer : MonoBehaviour
{
    private int health = 3;
    public GameObject levelWonCnavas;
    public GameObject levelLostCnavas;
    public GameObject particleEffect;
    public GameObject h1, h2, h3;
    public GameObject explosionSound;
    public obstacleMove[] obs;
    void Start()
    {

        Destroy(GameObject.Find("levelAudio"));

        for(int i = 0; i < obs.Length; i++)
        {
            obs[i].gameObject.GetComponent<obstacleMove>().enabled = false;
        }
        GetComponent<movementController>().enabled = false;
    }

    
    void Update()
    {
        if (Time.realtimeSinceStartup >=6)
        {
            for (int i = 0; i < obs.Length; i++)
            {
                obs[i].gameObject.GetComponent<obstacleMove>().enabled = true;
            }
            GetComponent<movementController>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("levelTrigger"))
        {
            levelWonCnavas.SetActive(true);
        }
        if (collision.gameObject.CompareTag("spike"))
        {
            Instantiate(explosionSound);
            Instantiate(particleEffect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            health--;
            if (health == 2)
            {
                Destroy(h3);
            }
             if (health == 1)
            {
                Destroy(h2);
            }
            if (health <=0)
            {
                Destroy(h1);
                GetComponent<movementController>().enabled = false;
                levelLostCnavas.SetActive(true);
            }
        }
    }

    
}
