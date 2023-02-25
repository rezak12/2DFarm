using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //_audioSource.volume = ...;
        _audioSource.Play();
    }

    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}
