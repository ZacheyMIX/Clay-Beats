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
    [SerializeField] private float _startSongPosition;
    [SerializeField] private float _currentNotePosition;
    [SerializeField] private Animator _anim;

    
    
    public void SetFallSpeed(float _newSpeed)
    {
        _fallSpeed = _newSpeed;
    }
    
    private void Start()
    {
        _startSongPosition = GameManager.instance._startSongPosition;
        _startPosY = transform.position.y;
        _currentSpeed = 0;
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        _currentNotePosition = transform.position.y;

        if (_falling)
        {
            //these two lines control the downward lerping of a standard note!
            float _newYPos = Mathf.Lerp(_startPosY, -450, _currentSpeed);
            _currentSpeed += _fallSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, _newYPos, transform.position.z);
        }

        if(transform.position.y <= 80)
        {
            if (!_hasFailed) 
            {
                //only let each note "die" one time
                _hasFailed = true;
                StartCoroutine(KillNote(false));
            }
        }
        else if(transform.position.y <= _startSongPosition)
        {
            GameManager.instance.CallStartSong();
        }
     
    }

    public void CallKillNote(bool _hit)
    {
        _hasFailed = true;
        StartCoroutine(KillNote(_hit));
    }

    private IEnumerator KillNote( bool _hit)
    {
        BoxCollider _bc = GetComponent<BoxCollider>();
        _bc.enabled = false;

        if (_hit)
        {
            _anim.SetTrigger("hit");
            _falling = false;
        }
        else
        {
        _anim.SetTrigger("fail");
        }
        //play a destroy animation here!
        //play a destroy sfx here!
        //until animations are implemented, we will just disable sprite image
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }



}
