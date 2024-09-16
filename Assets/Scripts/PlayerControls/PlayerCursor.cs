using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerCursor : MonoBehaviour
{

    PlayerControlls controls;
    [SerializeField]
    RectTransform cursor;
    [SerializeField]
    bool hold;
    [SerializeField]
    int playerIndex;

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
        controls.Gameplay.Start.performed += ctx => SceneManager.LoadScene("MainMenu");

    }

    //Handles Note Interaction
    //TODO check player index for score and handling of long notes
    private void actionA()
    {
        if(ACanBePressed) 
        {
            //Added this line so that instead of destroying the note here, we play a destroy animation first! - hayes
            currentObject.GetComponent<Note>().CallKillNote(true);
            OnNoteHitted?.Invoke();

            Debug.Log(currentObject);
            ACanBePressed = false;
            playSoundEffect(1);
            
        }
    }
    private void actionB()
    {
        if (BCanBePressed)
        {
            currentObject.GetComponent<Note>().CallKillNote(true);
            OnNoteHitted?.Invoke();

            Debug.Log(currentObject);
            BCanBePressed = false;
            playSoundEffect(1);
        }
    }
    private void actionX()
    {
        if (XCanBePressed)
        {
            currentObject.GetComponent<Note>().CallKillNote(true);
            OnNoteHitted?.Invoke();

            Debug.Log(currentObject);
            XCanBePressed = false;
            playSoundEffect(1);
        }
    }
    private void actionY()
    {
        if (YCanBePressed)
        {
            currentObject.GetComponent<Note>().CallKillNote(true);
            OnNoteHitted?.Invoke();

            Debug.Log(currentObject);
            YCanBePressed = false;
            playSoundEffect(1);
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
    //TODO remove debugs when sound effects are implemented
    private void playSoundEffect(int condition)
    {
        switch (condition)
        {
            case 0:
                SoundManager.PlaySound(SoundType.MISS);
                break;
            case 1:
                if (playerIndex == 0)
                    SoundManager.PlaySound(SoundType.LPAW);
                else
                    SoundManager.PlaySound(SoundType.RPAW);
                break;

        }
    }
}
