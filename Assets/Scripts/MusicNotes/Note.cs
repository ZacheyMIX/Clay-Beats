using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Note : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private bool _falling = true;
    [SerializeField] private float _fallSpeed = 1f;

    [Header("Note Characteristics")]
    //each color note has a unique int identifier
    //0=green, 1=red, 2=blue, 3=blue
    public int _noteType;

    private bool _hasFailed; 
  
    // Update is called once per frame
    void Update()
    {
        
        if (_falling)
        {
            //these two lines control the downward lerping of a standard note!
            float _newYPos = Mathf.Lerp(transform.position.y, -450, _fallSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, _newYPos, transform.position.z);
        }

        if(transform.position.y <= 50)
        {
            if (!_hasFailed) 
            {
                //only let each note "die" one time
                _hasFailed = true;
                StartCoroutine(FailNote());
            }
        }
     
    }

    private IEnumerator FailNote()
    {
        BoxCollider _bc = GetComponent<BoxCollider>();
        _bc.enabled = false;
        //play a destroy animation here!
        //play a destroy sfx here!
        //until animations are implemented, we will just disable sprite image
        GetComponent<RawImage>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}
