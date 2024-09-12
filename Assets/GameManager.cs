using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public NotePlayer _player;
    private bool _playedFirstNote = false;
    private bool _startedSong = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            if (!_playedFirstNote)
            {
                _playedFirstNote = true;
                StartCoroutine(PlayFirstNote());
            }
        }
    }

    private IEnumerator PlayFirstNote()
    {
        yield return new WaitForSeconds(1);
        _player.PlayFirstNote();
    }

    public void StartSong()
    {
        if (!_startedSong)
        {
            _startedSong = true;
        Debug.Log("started Song!");  
        }
        
    }
}
