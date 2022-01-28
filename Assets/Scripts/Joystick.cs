using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] private JoysticImage _image;
    [SerializeField] private Stick _stick;
    [SerializeField] private Canvas _joystickCanvas;
    private Vector3 _scale => _joystickCanvas.GetComponent<RectTransform>().lossyScale;
    private float _radius;

    private Vector3 _beganPosition;
    private Vector3 _direction => _cancelledPosition - _beganPosition;
    public Vector3 Direction => _direction.normalized;
    private Vector3 _cancelledPosition;

#region OnTouchBegan
    public delegate void Touch();
    public event Touch OnTouchBegan;
#endregion

#region OnTouchMoved
    public delegate void Moved();
    public event Moved OnTouchMoved;
#endregion

#region OnTouchCancelled
    public delegate void Cancelled();
    public event Cancelled OnTouchCancelled;
#endregion
    
    void Start()
    {
        _radius = (_image.Radius - _stick.Radius * 1.5f) * _scale.magnitude;
        OnTouchBegan += Show;
        OnTouchMoved += MoveStick;
        OnTouchCancelled += Hide;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTouchBegan.Invoke();
            _beganPosition = Input.mousePosition;
            _stick.Center = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            _cancelledPosition = Input.mousePosition;
            OnTouchMoved.Invoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnTouchCancelled.Invoke();
            _beganPosition = Vector3.zero;
        }
    }

    private void Show()
    {
        _image.Enabled(true);
        _stick.Enabled(true);
    }

    private void Hide()
    {
        _image.Enabled(false);
        _stick.Enabled(false);
    }

    private void MoveStick()
    {
        _stick.Move(_beganPosition, _cancelledPosition, _radius);
    }

}
