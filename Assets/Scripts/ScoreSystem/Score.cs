using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    public string scoreDisplay { 
        get 
        {
            if (isPlaying)
                return $"{(int)(currentScore / maxScore) * 100}%";
            else
                return "currently not playing a song";
        }
    }

    private bool isPlaying = false;
    private int maxScore;
    private int currentScore;

    /// <summary>
    /// initialize the score count.  A song's score will between 0% and 100%.
    ///   The score will start at 0% when initialize the score.
    /// </summary>
    /// <param name="noteCount"></param>
    public void InitializeGame(int noteCount) 
    {
        isPlaying = true;
        maxScore = noteCount;
        currentScore = 0;
    }

    public void NoteHitted() 
    {
        currentScore++;
    }

    public void EndSong() 
    {
        isPlaying = false;
    }
}
