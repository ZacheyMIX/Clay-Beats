using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Add sound names here (if you are adding sounds add to the end of the list)
public enum SoundType
{
    MISS,
    LPAW,
    RPAW,
    UIPLAY,
    UICONFIRM,
    UIBACK
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    // List of the sounds, each sound type can have multiple sounds
    [SerializeField] private SoundList[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    // Plays the sound, if there are mulitple sounds for the sound type
    // plays a random sound of that type (example: if you have 3 MISS
    // sounds it will pick one of the three at random
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip random = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(random, volume);
    }

    // fill out the names in the inspector
    // bhy getting names of the sound types
    // and creating an array of the names
#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for (int i = 0; i < soundList.Length; i++)
            soundList[i].name = names[i];
    }
#endif
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    // name of the type of sound (example: MISS)
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}
