using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textCrawler : MonoBehaviour
{
    public float scrollSpeed = 7;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 locUp = transform.TransformDirection(0, 1, 0);
        pos += locUp*scrollSpeed*Time.deltaTime;
        transform.position = pos;
    }
}
