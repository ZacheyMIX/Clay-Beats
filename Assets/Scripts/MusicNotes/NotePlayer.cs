using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using LitJson;

public class NotePlayer : MonoBehaviour
{
    private NoteManager _noteManager;

    [SerializeField] private List<float> _spawnTimes = new List<float>();
    [SerializeField] private List<string> _spawnColors = new List<string>();
    [SerializeField] private float _currentSongTime;

    public float _noteSpeed;
    
    
    
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
                string _color = _spawnColors[0];
                _noteManager.SpawnNote(_color, _noteSpeed);
                _spawnTimes.RemoveAt(0);
                _spawnColors.RemoveAt(0);
            }

        }
        

        _currentSongTime += Time.deltaTime;
    }


}
