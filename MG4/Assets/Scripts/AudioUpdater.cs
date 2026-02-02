// AudioUpdater.cs
using UnityEngine;

public class AudioUpdater : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _flapClip;
    [SerializeField] private AudioClip _scoreClip;
    [SerializeField] private AudioClip _gameOverClip;

    private Player _player;

    private void Awake()
    {
        _player = Locator.Instance.Player;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.Flapped += OnFlapped;
        _player.Scored += OnScored;
        _player.GameEnded += OnGameEnded;
    }
    
    private void OnFlapped()
    {
        _audioSource.PlayOneShot(_flapClip);
    }

    private void OnScored(int _)
    {
        _audioSource.PlayOneShot(_scoreClip);
    }

    private void OnGameEnded()
    {
        _audioSource.PlayOneShot(_gameOverClip);
    }
}
