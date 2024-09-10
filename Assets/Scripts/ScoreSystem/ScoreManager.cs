using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public enum playerPos
{
    PLAYER1,
    PLAYER2
}

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    Score p1Score;
    [SerializeField] GameObject p1ScoreText;
    [SerializeField] PlayerCursor p1Cursor;
   

    Score p2Score;
    [SerializeField] GameObject p2ScoreText;
    [SerializeField] PlayerCursor p2Cursor;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        p1Score = new Score(p1ScoreText.GetComponent<Animation>());
        p1ScoreText.GetComponent<ScoreDisplay>().score = p1Score;
        p1Cursor.OnNoteHitted.AddListener(p1Score.NoteHitted);

        InitializePlayerScore(playerPos.PLAYER1, 100);

#if p2scoreText != null && p2Cursor != null
        p2Score = new Score(p2ScoreText.GetComponent<Animation>());
        p2ScoreText.GetComponent<ScoreDisplay>().score = p1Score;
        p2Cursor.OnNoteHitted.AddListener(p2Score.NoteHitted);
#endif
    }

    public void InitializePlayerScore(playerPos player, int noteCount) 
    {
        if (player == playerPos.PLAYER1)
        {
            p1Score.InitializeGame(noteCount);
        }
    }

    public void EndPlayerScoreCount(playerPos player)
    {
        if (player == playerPos.PLAYER1)
        {
            p1Score.EndSong();
        }
    }

}
