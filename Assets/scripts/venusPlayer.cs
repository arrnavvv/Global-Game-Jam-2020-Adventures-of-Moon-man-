using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class venusPlayer : MonoBehaviour
{
    bool hasKey = false;
   public GameObject keySound;
    public GameObject LevelWonPanel;
    public GameObject doorSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Instantiate(doorSound, other.gameObject.transform.position, Quaternion.identity);
                LevelWonPanel.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
