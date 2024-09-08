using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

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
