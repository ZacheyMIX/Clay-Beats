using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundExample : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Period)) 
        {
            SoundManager.PlaySound(SoundType.MISS);
        }
    }
}
