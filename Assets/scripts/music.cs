using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public GameObject gm;
    void Start()
    {
        gm = this.gameObject;
        DontDestroyOnLoad(gm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
}
