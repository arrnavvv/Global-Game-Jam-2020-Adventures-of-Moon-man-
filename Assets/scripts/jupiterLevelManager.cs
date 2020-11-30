using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class jupiterLevelManager : MonoBehaviour
{
    private int currentQuestion = 1;
    public GameObject can1, can2, can3, can4, can5,levelWon;
    public TMP_InputField input1, input2, input3, input4, input5;
    string ans1 = "256", ans2 = "3", ans3 = "R", ans4 = "THE SUN RISES IN THE THE EAST", ans5 = "5";
    public GameObject buttonPressSound;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkAnswer()
    {
        Instantiate(buttonPressSound);
        if (currentQuestion == 1)
        {
            if (input1.text == ans1) { 
                can1.SetActive(false);
            can2.SetActive(true);
            currentQuestion++;
        }
        else
        {
            //wrong answer
            input1.text = "0";
        }
    }else if (currentQuestion == 2)
        {
            if (input2.text == ans2){
                 can2.SetActive(false);
            can3.SetActive(true);
            currentQuestion++;
        }
            else {
                //wrong answer
                input2.text = "0";

            }
        }else if (currentQuestion == 3)
        {
            if (input3.text == ans3)
            {
                can3.SetActive(false);
                can4.SetActive(true);
                currentQuestion++;
            }
            else
            {
                //wrong answer
                input3.text = "0";

            }

        }
        else if (currentQuestion == 4)
        {
            if (input4.text == ans4)
            {
                can4.SetActive(false);
                can5.SetActive(true);
                currentQuestion++;
            }
            else
            {
                //wrong answer
                input4.text = "0";

            }

        }
        else if (currentQuestion == 5)
        {
            if (input5.text == ans5)
            {
                can5.SetActive(false);
                levelWon.SetActive(true);
                currentQuestion++;
            }
            else
            {
                //wrong answer
                input5.text = "0";

            }

        }

       
    }
}
