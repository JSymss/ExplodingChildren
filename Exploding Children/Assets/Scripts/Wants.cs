using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Wants : MonoBehaviour, IDropHandler
{
    public Animator animator;


    public bool hasWant = false;

    public Text itemText;

    Color orange = new Color(1, 0.3f, 0);
    Color red = new Color(1, 0, 0);
    Color blue = new Color(0, 0, 1);

    public Type wantType;
    public Colour wantColour;
    public int CorrectItems;
    public int WinCond;

    public GameObject restartButton;
    public TextMeshProUGUI youWin;
    public TextMeshProUGUI youLose;

    // Start is called before the first frame update
    void Start()
    {
        
        CorrectItems = 0;
        WinCond = 4;
        
    }

    // Update is called once per frame
    void Update()
    { 

     if(hasWant == false)
        {
            wantType = (Type)Random.Range(0, 3);
            wantColour = (Colour)Random.Range(0, 3);
            hasWant = true;
            animator.SetBool("correctItem", false);
           

            string t = wantType.ToString();
            string c = wantColour.ToString();

            itemText.text = c + " " + t;
            if (c == "Orange")
            {
                itemText.color = orange;
            };
            if (c == "Red")
            {
                itemText.color = red;
            };
            if (c == "Blue")
            {
                itemText.color = blue;
            };
            if(CorrectItems >= WinCond )
            {
                if (animator.GetBool("childExploding") == false)
                {
                    animator.SetBool("Win",true);
                    Timer.pauseTimer = true;
                    restartButton.SetActive(true);
                    youWin.text = "You Win";
                    DragDrop.paused = true;
                }
            }
        }

    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && DragDrop.paused == false) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.SetActive(false);
            print(eventData.pointerDrag.GetComponent<Objects>());
            Debug.Log(wantColour);
            Debug.Log(wantType);

            //Run Coroutine to give animation time to play
            StartCoroutine("CheckHappy", eventData.pointerDrag.GetComponent<Objects>());
               



        }

    }

    IEnumerator CheckHappy(Objects o)
    {
        animator.SetBool("correctItem", true);
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("correctItem", false);

        if (wantColour == o.colour && wantType == o.type)
    {
        animator.SetBool("correctItem", true);
        hasWant = false;
            CorrectItems++;



        yield return new WaitForSeconds(0.8f);
        animator.SetBool("correctItem", false);
            //compare want and object

        }

    }

 
}
