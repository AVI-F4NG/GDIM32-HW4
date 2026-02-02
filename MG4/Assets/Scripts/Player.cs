using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _up = 2f;

    private Rigidbody2D _rb;
    private int _points;
    private bool _gameRuns;
    private bool _gameOverFired;
    public delegate void IntDelegate(int x);
    public event IntDelegate PointsChanged;
    public event Action Flapped;
    public event Action<int> Scored;
    public event Action GameEnded;

    private void Start()
    {
        _points = 0;
        _rb = GetComponent<Rigidbody2D>();
        _gameRuns = true;
        _gameOverFired = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _gameRuns)
        {
            Flap();
        }
    }

    private void Flap()
    {
        _rb.AddForce(Vector2.up * _up, ForceMode2D.Impulse);
        Flapped?.Invoke(); 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!_gameRuns) return;

        if (other.CompareTag("PassZone"))
        {
            _points += 1;

            PointsChanged?.Invoke(_points); 
            Scored?.Invoke(_points);        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pipe"))
        {
            _gameRuns = false;

            if (_gameOverFired) return;
            _gameOverFired = true;

            GameEnded?.Invoke();
        }
    }
}
