using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private NotePlayer _playerLeft;
    [SerializeField] private NotePlayer _playerRight;
    private bool _playedFirstNote = false;
    private bool _startedSong = false;
    public float _startSongPosition;

    [SerializeField] private AudioSource _currentSong;

    //The below region just creates a reference of this specific script that we can call from other scripts quickly
    #region Singleton

    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of playercontroller present!! NOT GOOD!");
            return;
        }

        instance = this;
    }

    #endregion

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
