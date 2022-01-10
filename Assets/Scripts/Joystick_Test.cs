using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Joystick_Test : MonoBehaviour
{
    

    private ControlType _controlType;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _anim;
    
    [SerializeField] private float _moveSpeed;
    private Vector3 _v3;
    enum ControlType {PC,Android };

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal * _moveSpeed,_rb.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)// ползунок сдвинут по вертикальной оси или по вертикальной
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
            _anim.SetBool("run", true);
        }
        else
            _anim.SetBool("run", false);
    }
}
