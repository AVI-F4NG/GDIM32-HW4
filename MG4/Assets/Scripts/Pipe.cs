using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private bool _canMove = true;
    private Player _player;

    private void OnEnable()
    {
        _player = Locator.Instance.Player;
        _player.GameEnded += StopMoving;
    }

    void Update()
    {
        if (!_canMove) return;
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void StopMoving()
    {
        _canMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyZone"))
        {
            Destroy(gameObject);
        }
    }
}
