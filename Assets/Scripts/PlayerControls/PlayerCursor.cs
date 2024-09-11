using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [HideInInspector]
    public UnityEvent OnNoteHitted;


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
    //TODO check player index for score and sound effect for both players
    private void actionA()
    {
        if(ACanBePressed) 
        {
            OnNoteHitted?.Invoke();

            Debug.Log("Hit");
            ACanBePressed = false;
            playSoundEffect(1);
            Destroy(currentObject);
        }
    }
    private void actionB()
    {
        if (BCanBePressed)
        {
            OnNoteHitted?.Invoke();

            Debug.Log("Hit");
            BCanBePressed = false;
            playSoundEffect(1);
            Destroy(currentObject);
        }
    }
    private void actionX()
    {
        if (XCanBePressed)
        {
            OnNoteHitted?.Invoke();

            Debug.Log("Hit");
            XCanBePressed = false;
            playSoundEffect(1);
            Destroy(currentObject);
        }
    }
    private void actionY()
    {
        if (YCanBePressed)
        {
            OnNoteHitted?.Invoke();

            Debug.Log("Hit");
            YCanBePressed = false;
            playSoundEffect(1);
            Destroy(currentObject);
        }
    }




    private void Update()
    {
    }

    //When the note enters the space of the cursor, allowing the cursor to be able to interact with the note; hitting the note
    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
        if (other.gameObject.tag == "AButton")
        { 
           ACanBePressed = true;
        }
        else if (other.gameObject.tag == "BButton")
        {
            BCanBePressed = true;
        }
        else if (other.gameObject.tag == "XButton")
        {
            XCanBePressed = true;
        }
        else if (other.gameObject.tag == "YButton")
        {
            YCanBePressed = true;
        }
    }

    //When the note exits the space of the cursor after entering, disallowing any input from the player; missing the note
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "AButton")
        {
            ACanBePressed = false;
        }
        else if (other.gameObject.tag == "BButton")
        {
            BCanBePressed = false;
        }
        else if (other.gameObject.tag == "XButton")
        {
            XCanBePressed = false;
        }
        else if (other.gameObject.tag == "YButton")
        {
            YCanBePressed = false;
        }
        playSoundEffect(0);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    //Plays sound effect based on given condition
    private void playSoundEffect(int condition)
    {
        switch (condition)
        {
            case 0:
                //SoundManager.PlaySound(SoundType.MISS);
                break;
            case 1: 
                //SoundManager.PlaySound(SoundType.LPAW);
                break;

        }
    }
}
