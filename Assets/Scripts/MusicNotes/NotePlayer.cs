using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePlayer : MonoBehaviour
{
    private string _jsonString;
    private NoteManager _noteManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _noteManager = GetComponent<NoteManager>();

       // SongData _songData = new SongData();
       // _songData._timeSignature = 0.75f;
       // _songData._duration = 30f;
       // _songData._bpm = 100;

      //  string json = JsonUtility.ToJson(_songData);
       // Debug.Log(json);

      //  SongData _loadedSongData = JsonUtility.FromJson<SongData>(json);
      //  Debug.Log(_loadedSongData);

      _jsonString = File.ReadAllText(Application.dataPath + "/Scripts/JSON/Test1.json");
        Debug.Log(_jsonString);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _noteManager.SpawnNote(true, "red", 1);
        }
    }


    private class SongData
    {
        public float _timeSignature;
        public float _duration;
        public float _bpm;
    }
    //template for calling note function! 
    //(bool _left, string _noteKey, int _spawnerKey)

}
