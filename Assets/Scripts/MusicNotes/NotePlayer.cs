using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using LitJson;

public class NotePlayer : MonoBehaviour
{
    [SerializeField] private TextAsset _textJson;
    private NoteManager _noteManager;
    
    [System.Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int mana;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    
    }

    public PlayerList myPlayerList = new PlayerList();

    // Start is called before the first frame update
    void Start()
    {
        _noteManager = GetComponent<NoteManager>();

        myPlayerList = JsonUtility.FromJson<PlayerList>(_textJson.text);
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
