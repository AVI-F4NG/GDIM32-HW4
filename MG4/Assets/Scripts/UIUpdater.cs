// UIUpdater.cs
using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _gameOverText;

    private Player _player;

    private void Awake()
    {
        _player = Locator.Instance.Player;
        _pointsText.text = "0";
        _gameOverText.gameObject.SetActive(false); 
    }

    private void OnEnable()
    {
        _player.PointsChanged += OnPointsChanged;
        _player.GameEnded += OnGameEnded;
    }

    private void OnPointsChanged(int points)
    {
        _pointsText.text = points.ToString();
    }

    private void OnGameEnded()
    {
        _gameOverText.gameObject.SetActive(true);
    }
}
