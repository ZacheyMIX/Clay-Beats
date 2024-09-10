using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{

    PlayerControlls controls;
    [SerializeField]
    RectTransform cursor;
    [SerializeField]
    bool hold;

    bool ACanBePressed;
    bool BCanBePressed;
    bool XCanBePressed;
    bool YCanBePressed;
    GameObject currentObject;


    private void Awake()
    {
        controls = new PlayerControlls();

        //Controlls need context in order to perform calls through lambda values
        controls.Gameplay.AButton.performed += ctx => actionA();
        controls.Gameplay.BButton.performed += ctx => actionB();
        controls.Gameplay.XButton.performed += ctx => actionX();
        controls.Gameplay.YButton.performed += ctx => actionY();

    }

    //Handles Note Interaction
    private void actionA()
    {
        if(ACanBePressed) 
        {
            Debug.Log("Hit");
            ACanBePressed = false;
            Destroy(currentObject);
        }
    }
    private void actionB()
    {
        if (BCanBePressed)
        {
            Debug.Log("Hit");
            BCanBePressed = false;
            Destroy(currentObject);
        }
    }
    private void actionX()
    {
        if (XCanBePressed)
        {
            Debug.Log("Hit");
            XCanBePressed = false;
            Destroy(currentObject);
        }
    }
    private void actionY()
    {
        if (YCanBePressed)
        {
            Debug.Log("Hit");
            YCanBePressed = false;
            Destroy(currentObject);
        }
    }




    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
        if (other.gameObject.tag == "AButton")
            ACanBePressed = true;
        else if(other.gameObject.tag == "BButton")
            BCanBePressed = true;
        else if (other.gameObject.tag == "XButton")
            XCanBePressed = true;
        else if (other.gameObject.tag == "YButton")
            YCanBePressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
         
        if (other.gameObject.tag == "AButton")
            ACanBePressed = false;
        else if (other.gameObject.tag == "BButton")
            BCanBePressed = false;
        else if (other.gameObject.tag == "XButton")
            XCanBePressed = false;
        else if (other.gameObject.tag == "YButton")
            YCanBePressed = false;
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
