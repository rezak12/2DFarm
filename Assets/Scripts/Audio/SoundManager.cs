using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //_audioSource.volume = ...;
    }

    
    public void PlaySound(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
    }
}
