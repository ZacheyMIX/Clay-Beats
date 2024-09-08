using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour
{
    Score score;
    Text text;
    void Start()
    {
        score = gameObject.GetComponentInParent<Score>();
        text = GetComponent<Text>();

        score.InitializeGame(57);
    }

    void Update()
    {
        text.text = score.scoreDisplay;
    }
}
