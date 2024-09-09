using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonMapper : MonoBehaviour
{
    //This is where we slot in the desired song map
    [SerializeField] private TextAsset _textJson;


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
        myPlayerList = JsonUtility.FromJson<PlayerList>(_textJson.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
