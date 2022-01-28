using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] Joystick _joystick;

    private void Start()
    {
        _joystick.OnTouchMoved += Move;
    }

    private void Move()
    {
        transform.position += new Vector3(_joystick.Direction.x, _joystick.Direction.z, _joystick.Direction.y) * Time.smoothDeltaTime * _speed;
    }

    
}
