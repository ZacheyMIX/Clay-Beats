using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using LitJson;

public class NotePlayer : MonoBehaviour
{
    private NoteManager _noteManager;

    public List<float> _timesToSpawn = new List<float>();
    public List<string> _notesToSpawn = new List<string>();
    [SerializeField] private float _currentSongTime;

    public float _noteSpeed;
    public bool _started = false;
    public bool _ended = false;
    public float _songDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        _noteManager = GetComponent<NoteManager>();
       
    }

    public void PlayFirstNote()
    {
        _started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_started)
        {
            if (!_ended)
            {
                SongUpdate();
            }
        }
    }

    private void SongUpdate()
    {
            if(_timesToSpawn.Count > 0)
            {
                float _difference = Mathf.Abs(_currentSongTime - _timesToSpawn[0]);
            
                if(_difference <= 0.01f)
                {
                    string _noteType = _notesToSpawn[0];
                    _noteManager.SpawnNote(_noteType, _noteSpeed);
                    _timesToSpawn.RemoveAt(0);
                    _notesToSpawn.RemoveAt(0);
                }

            }
        
            _currentSongTime += Time.deltaTime;

        if(_currentSongTime >= _songDuration)
        {
            EndSong();
        }

    }

    private void EndSong()
    {
        _ended = true;
    }

}
