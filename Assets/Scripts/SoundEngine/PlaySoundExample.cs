using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundExample : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Period)) 
        {
            SoundManager.PlaySound(SoundType.MISS);
        }
    }
}
