using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonMapper : MonoBehaviour
{
    //This is where we slot in the desired song map
    [SerializeField] private TextAsset _textJson;

    [SerializeField] private string[] _spawnColors;
    [SerializeField] private float[] _spawnTimes;
    [SerializeField] private NotePlayer _notePlayer;


    [System.Serializable]
    public class SongLength
    {
        public float duration;
    }

    public SongLength duration;

    [System.Serializable]
    public class Header
    {
        public int PPQ;
        public int bpm;
        public string name;

    }

    [System.Serializable]
    public class HeaderList
    {
        public Header header;
    }

    public HeaderList _headerList = new HeaderList();


    [System.Serializable]
    public class Note
    {

        public string name;
        public float midi;
        public float time;
        public float velocity;
        public float duration;
    }


    [System.Serializable]
    public class TrackList
    {
        public Track[] tracks;
    }

    [System.Serializable]
    public class Track
    {
        public Note[] notes;
        public float length;
    }

    public TrackList _trackList = new TrackList();


    // Start is called before the first frame update
    void Start()
    {

        _trackList = JsonUtility.FromJson<TrackList>(_textJson.text);
        _headerList = JsonUtility.FromJson<HeaderList>(_textJson.text);
        duration = JsonUtility.FromJson<SongLength>(_textJson.text);
        

        FillNotePlayer();
    }

    private void FillNotePlayer()
    {

        List<GameObject> _notesToSpawn = new List<GameObject>();
        List<float> _timesToSpawn = new List<float>();

        int i = 0;

          foreach (Note note in _trackList.tracks[0].notes)
          {
              string _noteName = note.name;
              float _noteTime = note.time;

              _notePlayer._timesToSpawn.Add(_noteTime);

            if (_noteName == "C4")
              {
                  _noteName = "A";
              }
              else if(_noteName == "D4")
              {
                  _noteName = "B";
              }
              else if(_noteName == "E4")
              {
                  _noteName = "X";
              }
              else if(_noteName == "F4")
              {
                  _noteName = "Y";
              }
              else if(_noteName == "C5")
              {
                  _noteName = "A";
              }
              else if(_noteName == "D5")
              {
                  _noteName = "B";
              }
              else if(_noteName == "E5")
              {
                  _noteName = "X";
              }
            else
            {
                _noteName = "Y";
            }

              _notePlayer._notesToSpawn.Add(_noteName);
          }

           _notePlayer._songDuration = duration.duration;

    }
        
    
}
