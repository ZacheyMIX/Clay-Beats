using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonMapper : MonoBehaviour
{
    //This is where we slot in the desired song map
    [SerializeField] private TextAsset _textJson;

    [SerializeField] private string[] _spawnColors;
    [SerializeField] private float[] _spawnTimes;
    private NotePlayer _notePlayer;


    [System.Serializable]
    public class Song
    {
        public string title;
        public int duration;
        public int bpm;
    }

    [System.Serializable]
    public class SongWhole
    {
        public Song[] song;
    }

    public SongWhole _songData = new SongWhole();

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
    public class NoteList
    {
        public Note[] notes; 
    }

    public NoteList _noteList = new NoteList();

    // Start is called before the first frame update
    void Start()
    {
        _noteList = JsonUtility.FromJson<NoteList>(_textJson.text);
        _notePlayer = GetComponent<NotePlayer>();

        FillNotePlayer();
    }

   private void FillNotePlayer()
    {
        List<GameObject> _notesToSpawn = new List<GameObject>();
        List<float> _timesToSpawn = new List<float>();

        //int i = 0;

        foreach (Note _note in _noteList.notes)
        {
            string _noteName = _note.name;
            float _noteTime = _note.time;

            _notePlayer._timesToSpawn.Add(_noteTime);

            if(_noteName == "C4")
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
                _noteName = "left";
            }
            else if(_noteName == "D5")
            {
                _noteName = "middle";
            }
            else if(_noteName == "E5")
            {
                _noteName = "right";
            }

            _notePlayer._notesToSpawn.Add(_noteName);
        }

        _notePlayer._hasStarted = true;
    }
}
