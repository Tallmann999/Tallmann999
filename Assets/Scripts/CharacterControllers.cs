using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllers : MonoBehaviour
{
    [SerializeField] private float _speedMove;
     private float _gravitiPlayer;


    private Vector3 _moveVector; // направление персонажа 

    private CharacterController _chContoller; // ссылка на компонент
    private Animator _chAnimator;


    private void Start()
    {
        _chContoller = GetComponent<CharacterController>();
        _chAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        CharacterMove();
        GamingGravity();
    }
     private void CharacterMove() // метод  перемещения персонажа
    {

        // Перемещение по поверхности
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal")* _speedMove;
        _moveVector.z = Input.GetAxis("Vertical") * _speedMove;


        // Поворот персонажа в сторону направления перемещения
        if(Vector3.Angle(Vector3.forward,_moveVector) >1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
            {

            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        _moveVector.y = _gravitiPlayer;// расчёт гравитации выполнять после поворота!!!
        _chContoller.Move(_moveVector * Time.deltaTime); //метод передвижения по направлению
    }


    private void GamingGravity()
    {
        if (!_chContoller.isGrounded) _gravitiPlayer -= 20f * Time.deltaTime;
        else _gravitiPlayer = -1f;

    }
}
