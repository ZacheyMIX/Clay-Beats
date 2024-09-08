using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float cursorSpeed = 1000f;
    [SerializeField]
    RectTransform cursor;
    [SerializeField]
    float maxWidth;
    [SerializeField]
    float minWidth;
    [SerializeField]
    float defaultPos;
    [SerializeField]
    private int playerIndex;

    private CharacterController controller;
    private Vector2 inputVector = Vector2.zero;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public int GetPlayerIndex() 
    { 
        return playerIndex; 
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 m = new Vector2(inputVector.x, 0) * Time.deltaTime * cursorSpeed;
        if (cursor.anchoredPosition.x + m.x > defaultPos + minWidth && cursor.anchoredPosition.x + m.x < defaultPos + maxWidth)
            cursor.transform.Translate(m, Space.World);
    }
}
