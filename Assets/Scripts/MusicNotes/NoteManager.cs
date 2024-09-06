using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    //This dictionary carries all of the possible notes that could be spawned
    [SerializeField] private Dictionary<string, GameObject> _noteObjects = new Dictionary<string, GameObject>();

    //This list carries all of the possible places a note could spawn from
    [SerializeField] private List<Transform> _spawnerObjects = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnNote(string _noteKey, int _spawnerKey)
    {
        //Creating the references for the spawned object and position
        GameObject _newObject = _noteObjects[_noteKey];
        Vector3 _spawnerPosition = _spawnerObjects[_spawnerKey].position;

        //Spawning the object at position
        GameObject _newNote = GameObject.Instantiate(_noteObjects["red"], _spawnerPosition, Quaternion.identity);
    }
}
