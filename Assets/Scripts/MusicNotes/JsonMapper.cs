using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonMapper : MonoBehaviour
{
    //This is where we slot in the desired song map
    [SerializeField] private TextAsset _textJson;

    [SerializeField] private string[] _spawnColors;
    [SerializeField] private float[] _spawnTimes;


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
        _songData = JsonUtility.FromJson<SongWhole>(_textJson.text);
        _noteList = JsonUtility.FromJson<NoteList>(_textJson.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
