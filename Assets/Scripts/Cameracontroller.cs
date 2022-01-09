using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public float dumping = 1.5f; // небольшое сглаживание камеры (Скольжение)
     public Vector3 target; // направление камеры
   

    public GameObject  player;



    private void Start()
    {
        target = transform.position - player.transform.position;
    }
    private void Update()
    {
        transform.position = player.transform.position + target; 
    }
}
