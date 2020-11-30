using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saturnPlayer : MonoBehaviour
{
   public GameObject[] obj;
    public GameObject levelLostPan;
    public GameObject levelWonPan;
    int timesSpawned = 0;
    private int health = 2;
    public GameObject h1, h2;
    public GameObject buzzerSound;
    public GameObject explosionSound;
    void Start()
    {
      
        InvokeRepeating("spawner", 6.5f, 3.0f);
        InvokeRepeating("check", 1.0f, 1.0f);
       
    }

    private void spawner()
    {
        Instantiate(buzzerSound);
        for (int i = 0; i < 13; i++)
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height/2)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            
            Instantiate(obj[Random.Range(0,obj.Length)], spawnPosition, Quaternion.identity);
        }
        timesSpawned++;
    }

    void Update()
    {
        
    }

    private void check()
    {
        if (timesSpawned == 6)
        {
            Destroy(levelLostPan);
            levelWonPan.SetActive(true);
            CancelInvoke();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("finalEnemy"))
        {
            Instantiate(explosionSound);
            health--;
            if (health == 1)
            {
                Destroy(h2);
            }
            else if (health == 0)
            {
                Destroy(h1);
                levelLostPan.SetActive(true);
                CancelInvoke();
            }
        }
    }
}
