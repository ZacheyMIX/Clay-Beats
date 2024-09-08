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
    float maxWidth = 100;
    [SerializeField]
    float minWidth = -100;

    Vector2 move;

    public bool actionPress = false;


    private void Awake()
    {
        controls = new PlayerControlls();

        controls.Gameplay.Action.performed += ctx => Action();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
    }

    private void Action()
    {
        if(gameObject.GetComponent<CollisionManager>().canBePressed) 
        {
            Debug.Log("Hit");
        }
    }

    
    private void Update()
    {
        //Moves Cursor based on restrictions
        Vector2 m = new Vector2(move.x, 0) * Time.deltaTime * cursorSpeed;
        if (cursor.anchoredPosition.x + m.x > minWidth && cursor.anchoredPosition.x + m.x < maxWidth)
        {
            cursor.transform.Translate(m, Space.World);
        }
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
