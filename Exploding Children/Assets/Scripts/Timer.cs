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
    public Text youWin;
    public TextMeshProUGUI youLose;

   
    void Start()
    {
        startTime = Time.time;
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        float t = Time.time - startTime;
        //When the timer hits 0, child explodes

        if (t >= 10)
        {
            animator.SetBool("childExploding", true);
            restartButton.SetActive(true);
            youLose.text = "You Lose";
            DragDrop.paused = true;
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
        print(t);
    }
}
