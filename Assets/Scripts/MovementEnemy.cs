using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    private float _speed = 3f;
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        Destroy();
    }

    private void Destroy()
    {
        if (_targetPosition == transform.position)
            Destroy(gameObject);
    }
}