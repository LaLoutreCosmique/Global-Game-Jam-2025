using System;
using DG.Tweening;
using UnityEngine;

public class Tortue : MonoBehaviour
{
     [SerializeField]private float moveSpeed;
     private bool direction = true;
     public float rotationSpeed = 0.5f;

     private void Update()
     {
         if (!direction)
         {
             transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
         }
         else
         {
             transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
         }
     }

     private void OnTriggerEnter2D(Collider2D other)
    {Debug.Log("collision");
        transform.DOScaleY(-transform.localScale.y, rotationSpeed);
        direction = !direction;
        /* (other.gameObject.CompareTag("turtlezone"))
        {
            Debug.Log("turtle");
            moveSpeed *= -1;
        }*/
    }
}
