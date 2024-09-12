using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Note : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private bool _falling = true;
    public float _fallSpeed = 1f;
    private float _startPosY;
    private bool _hasFailed;
    private float _currentSpeed;
    private float _startSongPosition;
    
    
    public void SetFallSpeed(float _newSpeed)
    {
        _fallSpeed = _newSpeed;
    }
    
    private void Start()
    {
        _startSongPosition = GameManager.instance._startSongPosition;
        _startPosY = transform.position.y;
        _currentSpeed = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_falling)
        {
            //these two lines control the downward lerping of a standard note!
            float _newYPos = Mathf.Lerp(_startPosY, -450, _currentSpeed);
            _currentSpeed += _fallSpeed * Time.deltaTime;
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
        else if(transform.position.y <= _startSongPosition)
        {
            Debug.Log("StartedSong~");
            GameManager.instance.StartSong();
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
