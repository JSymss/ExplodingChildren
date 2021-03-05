using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    public Type type;
    public Colour colour;

    public bool Check(Want want)
    {
        if(want.ref == colour || want.ref == type)
        {
            if (want.ref == colour && want.ref == type)
            {
                return true;
            }
                
           if()
            {
                return true;
            }

        }
        return false; 
    }

}
