using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{

    //This List contains all of the note objects that are then stored in the below dictionary
    [SerializeField] private GameObject[] _notesPool;

    [SerializeField] private string[] _stringsPool;

    //This dictionary carries all of the possible notes that could be spawned
    [SerializeField] private Dictionary<string, GameObject> _noteObjects = new Dictionary<string, GameObject>();

    //These lists carry all of the possible places a note could spawn from
    [SerializeField] private List<Transform> _leftSpawnerObjects = new List<Transform>();
    [SerializeField] private List<Transform> _rightSpawnerObjects = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
       //forloop collects all string and gameobject data to form a dictionary for notes  
        int i = 0;
        foreach(GameObject note in _notesPool)
        {
            _noteObjects.Add(_stringsPool[i], note);
            i++;
        }
    }

    public void SpawnNote(bool _left, string _noteKey, int _spawnerKey)
    {
        //Creating the references for the spawned object and position
        GameObject _newObject = _noteObjects[_noteKey];

        Vector3 _spawnerPosition;
        Transform _spawnerTransform;

        if (_left)
        {
             _spawnerTransform = _leftSpawnerObjects[_spawnerKey];
            
        }
        else
        {
             _spawnerTransform = _rightSpawnerObjects[_spawnerKey];
        }
        
        _spawnerPosition = _spawnerTransform.position;

        //Spawning the object at position
         GameObject _newNote = GameObject.Instantiate(_noteObjects["red"], _spawnerPosition, Quaternion.identity);
        _newNote.transform.SetParent(_spawnerTransform);
        _newNote.transform.localPosition = Vector3.zero;
    }
}
