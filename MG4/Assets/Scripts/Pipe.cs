using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    
    void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("destroy");
        if (other.CompareTag("DestroyZone"))
        {
            Destroy(gameObject);
            Debug.Log("destroy");
        }
    }
}
