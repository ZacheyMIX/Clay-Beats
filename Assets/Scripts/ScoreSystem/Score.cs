using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Score
{

    public string scoreDisplay {
        get
        {
            if (isPlaying)
                return $"{(int)(((float)currentScore / maxScore) * 100)}%";
            else
                return "currently not playing a song";
        }
    }

    public bool isPlaying { get; private set; } = false;
    private int maxScore;
    private int currentScore;

    Animation an;

    public Score(Animation textAnimation)
    {
        an = textAnimation;
    }

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
        an?.Play();
    }

    public void EndSong() 
    {
        isPlaying = false;
    }


#if UNITY_INCLUDE_TESTS

    /// <summary>
    /// tests for adding score and its animation
    /// </summary>
    /// <returns></returns>
    IEnumerator TestNoteHitted()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            NoteHitted();
        }
    }

#endif
}
