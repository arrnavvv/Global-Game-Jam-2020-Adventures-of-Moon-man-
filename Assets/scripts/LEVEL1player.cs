using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEVEL1player : MonoBehaviour
{

    
    private int health = 3;
    public GameObject heartHealthImage1;
    public GameObject heartHealthImage2;
    public GameObject heartHealthImage3;

    
    public GameObject levelCompleteUI;
    public GameObject levelLostUI;
    private Vector3 pos1,pos2,pos3;
    public GameObject effect;
    public GameObject heartEffect;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = heartHealthImage1.transform.position;
        pos2 = heartHealthImage2.transform.position;
        pos3 = heartHealthImage3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            health -= 1;
            if (health == 2)
            {
                heartHealthImage3.SetActive(false);
            }else if (health == 1)
            {
                heartHealthImage2.SetActive(false);
            }
            else if (health == 0)
            {
                heartHealthImage1.SetActive(false);
                GetComponent<movementController>().enabled = false;
                levelLostUI.SetActive(true);
            }
        }

        if (collision.gameObject.tag == "levelTrigger")
        {
            levelCompleteUI.SetActive(true);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("lifePick"))
        {
            
            if (health != 3)
            {
                Instantiate(heartEffect, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                health += 1;
                if (health == 3)
                    heartHealthImage3.SetActive(true);
                else if(health==2)
                    heartHealthImage2.SetActive(true);
            }
        }
    }
}
