using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllers : MonoBehaviour
{
     public float _speedMove;// скорость движения 
     public float _jumpForse; //сила прыжка
     private float _gravitiForce; // гравитация персонажа


    private Vector3 _moveVector; // направление  движения персонажа 

    private CharacterController _chContoller; // компонент контроллер
    private Animator _chAnimator; // компонент аниматор


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
        if (_chContoller.isGrounded) // ограничение движения во время прыжка
        {
            _chAnimator.ResetTrigger("Jump");// отмена тригерра в аниматоре jump
            _chAnimator.SetBool("Falling", false);

            // Перемещение по поверхности
            _moveVector = Vector3.zero; // обновление вектора движения
            _moveVector.x = Input.GetAxis("Horizontal") * _speedMove ; //оси движения персонажа
            _moveVector.z = Input.GetAxis("Vertical") * _speedMove ;// оси движения персонажа


            // анимация передвижения персонажа
            if (_moveVector.x != 0 || _moveVector.z != 0) _chAnimator.SetBool("run", true);//условие при котором будет меняться анимация
            else _chAnimator.SetBool("run", false);


            // Поворот персонажа в сторону направления перемещения
            if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
            {

                Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedMove, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);// поворот вектрора
            }
        }
        else
        {
            if (_gravitiForce < -3f) _chAnimator.SetBool("Falling", true);
        }
            _moveVector.y = _gravitiForce;// расчёт гравитации выполнять после поворота!!!
            _chContoller.Move(_moveVector* Time.deltaTime) ; //метод передвижения по направлению
        
    }


    private void GamingGravity() // гравитация персонажа
    {
        if (!_chContoller.isGrounded) _gravitiForce -= 20f * Time.deltaTime  ;// проверка персонажа на гравитацию
        else _gravitiForce = -1f; //после приземления сила гравитации -1
        if (Input.GetKeyDown(KeyCode.Space) && _chContoller.isGrounded)
        {
            _gravitiForce = _jumpForse; // прыжок персонажа
            _chAnimator.SetTrigger("Jump"); // тригер в анимации jump
        }

    }
}
