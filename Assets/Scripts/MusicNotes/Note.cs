using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Note : MonoBehaviour
{
    [SerializeField] private bool _falling = true;
    [SerializeField] private float _fallSpeed = 1f;
    
   

    // Update is called once per frame
    void Update()
    {
        if (_falling)
        {
            float _newYPos = Mathf.Lerp(transform.position.y, -450, _fallSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, _newYPos, transform.position.z);
       
        }
     
    }
}
