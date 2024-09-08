using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePlayer : MonoBehaviour
{

    private NoteManager _noteManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _noteManager = GetComponent<NoteManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _noteManager.SpawnNote(true, "red", 1);
        }
    }



    //template for calling note function! 
    //(bool _left, string _noteKey, int _spawnerKey)

}
