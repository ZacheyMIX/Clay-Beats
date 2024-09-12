using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private NotePlayer _playerLeft;
    [SerializeField] private NotePlayer _playerRight;
    private bool _playedFirstNote = false;
    private bool _startedSong = false;

    [SerializeField] private AudioSource _currentSong;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayFirstNote());
    }

    private IEnumerator PlayFirstNote()
    {
        yield return new WaitForSeconds(1);
        _playerLeft.PlayFirstNote();
        _playerRight.PlayFirstNote();
    }

    public void StartSong()
    {
        if (!_startedSong)
        {
            _startedSong = true;
            Debug.Log("started Song!");
            _currentSong.Play();
        }
        
    }
}
