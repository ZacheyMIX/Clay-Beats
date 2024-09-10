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
    public bool _hasStarted = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _noteManager = GetComponent<NoteManager>();
       
    }


    // Update is called once per frame
    void Update()
    {
        if (_hasStarted)
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

        }
    }

}
