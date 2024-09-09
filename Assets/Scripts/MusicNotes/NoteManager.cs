using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{

    //This List contains all of the note objects that are then stored in the below dictionary
    [SerializeField] private GameObject[] _notesPool;

    [SerializeField] private string[] _stringsPool;

    //This dictionary carries all of the possible notes that could be spawned
    private Dictionary<string, GameObject> _noteObjects = new Dictionary<string, GameObject>();

    //This list carries all of the possible places a note could spawn from
    [SerializeField] private List<Transform> _spawnerObjects = new List<Transform>();

    //This dictionary carries the combined notes with their spawn locations!
    private Dictionary<string, Transform> _spawnLocations = new Dictionary<string, Transform>();

    // Start is called before the first frame update
    void Start()
    {
       //forloop collects all string and gameobject data to form a dictionary for notes  
        int i = 0;
        foreach(GameObject note in _notesPool)
        {
            _noteObjects.Add(_stringsPool[i], note);
            _spawnLocations.Add(_stringsPool[i], _spawnerObjects[i]);
            i++;
        }

        i = 0;

    }

    public void SpawnNote(string _noteKey, float _noteSpeed)
    {
        //Creating the references for the spawned object and position
        GameObject _newObject = _noteObjects[_noteKey];

        Vector3 _spawnerPosition;
        Transform _spawnerTransform;

        _spawnerTransform = _spawnLocations[_noteKey];
        _spawnerPosition = _spawnerTransform.position;

        //Spawning the object at position
         GameObject _newNote = GameObject.Instantiate(_noteObjects[_noteKey], _spawnerPosition, Quaternion.identity);
        _newNote.transform.SetParent(_spawnerTransform);
        _newNote.transform.localPosition = Vector3.zero;

        //Setting the speed of each note to match the song!
        Note _noteScript = _newNote.GetComponent<Note>();
        _noteScript.SetFallSpeed(_noteSpeed);
    }
}
