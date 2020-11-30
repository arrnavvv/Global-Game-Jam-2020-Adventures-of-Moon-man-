using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public Animator anim;
     float transitionTime = 1f;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void nextLevel()
    {
        
      StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void retryLevel()
    {
      StartCoroutine( loadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void quit()
    {
        Application.Quit();
    }

    IEnumerator loadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelIndex);
    }
    
    public void playAgain()
    {
        StartCoroutine(loadLevel(0));
    }
}
