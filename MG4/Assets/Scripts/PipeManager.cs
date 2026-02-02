using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PipeManager : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _minY = -1.7f;
    [SerializeField] private float _maxY = 2.4f;

    private Player _player;
    private Coroutine _spawnRoutine;

    private void Awake()
    {
        _player = Locator.Instance.Player;
    }

    private void OnEnable()
    {
        _player.GameEnded += OnGameEnded;
    }

    private void Start()
    {
        _spawnRoutine = StartCoroutine(SpawnPipes());
    }

    private void OnDisable()
    {
        _player.GameEnded -= OnGameEnded;
    }

    private void OnGameEnded()
    {
        StopCoroutine(_spawnRoutine);
    }

    private IEnumerator SpawnPipes()
    {
        while (true)
        {
            Vector3 pos = transform.position;
            pos.y = Random.Range(_minY, _maxY);
            Instantiate(_pipePrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
