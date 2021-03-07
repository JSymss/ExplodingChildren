using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Wants : MonoBehaviour
{
    public enum Type { Bear, Ball, Drink}
    public enum Colour { Red, Orange, Blue}
    public bool hasWant = false;

    public Text itemText;


    public Type wantType;
    public Colour wantColour;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
     if(hasWant == false)
        {
            wantType = (Type)Random.Range(0, 3);
            wantColour = (Colour)Random.Range(0, 3);
            hasWant = true;

            string t = wantType.ToString();
            string c = wantColour.ToString();

            itemText.text = c + " " + t;
        }

        
    }
}
