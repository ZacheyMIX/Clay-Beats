using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using LitJson;

public class NotePlayer : MonoBehaviour
{
    private NoteManager _noteManager;

    [SerializeField] private List<float> _spawnTimes = new List<float>();
    [SerializeField] private float _currentSongTime;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _noteManager = GetComponent<NoteManager>();

    }


    // Update is called once per frame
    void Update()
    {
        
        if(_spawnTimes.Count > 0)
        {
            float _difference = Mathf.Abs(_currentSongTime - _spawnTimes[0]);
            
            if(_difference <= 0.01f)
            {
                _noteManager.SpawnNote(true, "red", 1);
                _spawnTimes.RemoveAt(0);
            }

        }
        

        _currentSongTime += Time.deltaTime;
        
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _noteManager.SpawnNote(true, "red", 1);
        }
    }

    //template for calling note function! 
    //(bool _left, string _noteKey, int _spawnerKey)

}
