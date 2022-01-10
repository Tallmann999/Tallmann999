using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Joystick_Test : MonoBehaviour
{
    

    public ControlType _controlType;
   public enum ControlType {PC,Android };
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _anim;
    
    [SerializeField] private float _moveSpeed;
    private Vector3 _v3;
    private Vector3 _vvv3;




    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    if(_controlType == ControlType.PC)
    //    {
    //        _v3 = new Vector3(Input.GetAxisRaw("Horizontal") ,0, Input.GetAxisRaw("Vertical"))*_moveSpeed * Time.deltaTime;
            
    //    }
       
    //}




    private void FixedUpdate()
    {
        if (_controlType == ControlType.Android)
        {
            _rb.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rb.velocity.y, _joystick.Vertical * _moveSpeed);

            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)// ползунок сдвинут по вертикальной оси или по вертикальной
            {
                transform.rotation = Quaternion.LookRotation(_rb.velocity);
                _anim.SetBool("run", true);
            }
            else
                _anim.SetBool("run", false);
        }
        else if (_controlType == ControlType.PC)
        {
            _rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal")* _moveSpeed,0, Input.GetAxisRaw("Vertical")*_moveSpeed);
            if (_rb.velocity.x != 0 || _rb.velocity.z != 0)// ползунок сдвинут по вертикальной оси или по вертикальной
            {
                transform.rotation = Quaternion.LookRotation(_rb.velocity);
                _anim.SetBool("run", true);
            }
            else
                _anim.SetBool("run", false);
        }
    }
}
