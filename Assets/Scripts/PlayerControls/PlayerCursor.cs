using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{

    PlayerControlls controls;
    [SerializeField]
    RectTransform cursor;
    [SerializeField]
    float cursorSpeed = 1000f;
    [SerializeField]
    float maxWidth;
    [SerializeField]
    float minWidth;
    [SerializeField]
    float defaultPos;


    Vector2 move;


    private void Awake()
    {
        controls = new PlayerControlls();

        //Controlls need context in order to perform calls through lambda values
        controls.Gameplay.Action.performed += ctx => Action();
    }

    //Handles Note Interaction
    private void Action()
    {
        if(gameObject.GetComponent<CollisionManager>().canBePressed) 
        {
            Debug.Log("Hit");
        }
    }

    
    private void Update()
    {
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
