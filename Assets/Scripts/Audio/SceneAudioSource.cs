using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudioSource : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
