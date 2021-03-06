using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    public Animator animator;
    public GameObject restartButton;
    public TextMeshProUGUI youWin;
    public TextMeshProUGUI youLose;
    public static bool pauseTimer = false;

   
    void Start()
    {
        startTime = Time.time;
        restartButton.SetActive(false);
        pauseTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseTimer == false)
        {
            float t = Time.time - startTime;
            //When the timer hits 0, child explodes

            if (t >= 10)
            {
                if (animator.GetBool("Win") == false)
                {
                    animator.SetBool("childExploding", true);
                    restartButton.SetActive(true);
                    youLose.text = "You Lose";
                    DragDrop.paused = true;
                }
            }
            //Stop counting if time is at 10 seconds
            if (Time.time - startTime >= 10)
                return;
            //Change colour at 5 seconds
            if (Time.time - startTime >= 5)
                timerText.color = Color.yellow;
            //Display time to 1 decimal point as text string
            string p = (10 - t).ToString("f1");
            timerText.text = p;
        }
    }
}
