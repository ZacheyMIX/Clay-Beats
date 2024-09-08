using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //Defines what notes enter, and when the player can perform an action
    //TODO: Define different inputs, and short and long notes
    public bool canBePressed; 
    private void OnTriggerEnter(Collider other)
    {
        canBePressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canBePressed = false;
    }
}
