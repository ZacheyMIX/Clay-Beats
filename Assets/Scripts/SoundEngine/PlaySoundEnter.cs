using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plays a sound when an animation state is entered
public class PlaySoundEnter : StateMachineBehaviour
{
    [SerializeField] private SoundType sound;
    // Volume is between 0 and 1, 1 by default
    [SerializeField, Range(0,1)] private float volume = 1;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.PlaySound(sound, volume);
    }
}
