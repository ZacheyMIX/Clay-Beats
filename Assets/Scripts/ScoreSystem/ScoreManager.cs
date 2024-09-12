using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public enum playerPos
{
    PLAYER1,
    PLAYER2
}

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    [Header("Player 1 score settings")]
    Score p1Score;
    [SerializeField] GameObject p1ScoreText;
    [SerializeField] PlayerCursor p1Cursor;
    Text p1Text;
    Animation t1Animation;


    [Header("Player 2 score settings")]
    Score p2Score;
    [SerializeField] GameObject p2ScoreText;
    [SerializeField] PlayerCursor p2Cursor;
    Text p2Text;
    Animation t2Animation;


    [SerializeField] ClayPotTransformation clayControl;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        p1Score = new Score();
        p1Text = p1ScoreText.GetComponent<Text>();
        p1Text.text = p1Score.scoreDisplay;
        t1Animation = p1ScoreText.GetComponent<Animation>();

        
        if (p2ScoreText != null && p2Cursor != null)
        {
            p2Score = new Score();
            p2Text = p2ScoreText.GetComponent<Text>();
            p2Text.text = p2Score.scoreDisplay;
            t2Animation = p1ScoreText.GetComponent<Animation>();

            p2Cursor.OnNoteHitted.AddListener(p2Score.NoteHitted);

            p1Cursor.OnNoteHitted.AddListener(() =>
            {
                p2Text.text = p2Score.scoreDisplay;
                t2Animation.Stop();
                t2Animation.Play();
                clayControl.Progress = CalculateTotalClayProgress();
            });
        }
        
        //update the score, update the text and invoke the animation
        p1Cursor.OnNoteHitted.AddListener(p1Score.NoteHitted);
        p1Cursor.OnNoteHitted.AddListener(() =>
        {
            p1Text.text = p1Score.scoreDisplay;
            t1Animation.Stop();
            t1Animation.Play();
            clayControl.Progress = CalculateTotalClayProgress();
        });

        //InitializePlayerScore(playerPos.PLAYER1, 100);
        //InvokeRepeating("TestHit", 0, 0.5f);
    }

    public void InitializePlayerScore(playerPos player, int noteCount) 
    {
        if (player == playerPos.PLAYER1)
        {
            p1Score?.InitializeGame(noteCount);
            p1Text.text = p1Score.scoreDisplay;
        }
        else if (player == playerPos.PLAYER2)
        {
            p2Score?.InitializeGame(noteCount);
            p2Text.text = p2Score.scoreDisplay;
        }

    }

    public void EndPlayerScoreCount(playerPos player)
    {
        if (player == playerPos.PLAYER1)
        {
            p1Score?.EndSong();
        }
        else if (player == playerPos.PLAYER2)
        {
            p2Score?.EndSong();
        }
    }


    float CalculateTotalClayProgress() 
    {
        if (p2ScoreText != null && p2Cursor != null)
        {
            return (p1Score.ScoreProgress() + p2Score.ScoreProgress()) / 2;
        }
        else
            return p1Score.ScoreProgress();
    }

    private void TestHit()
    {
        p1Cursor.OnNoteHitted.Invoke();
    }
}
