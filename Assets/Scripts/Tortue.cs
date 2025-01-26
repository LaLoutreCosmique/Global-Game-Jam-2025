using System;
using UnityEngine;

public class Tortue : MonoBehaviour
{
     [SerializeField]private float moveSpeed;

     private void Update()
     {
         transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
     }

     private void OnTriggerEnter2D(Collider2D other)
    {Debug.Log("collision");
        if (other.gameObject.CompareTag("turtlezone"))
        {
            Debug.Log("turtle");
            moveSpeed *= -1;
        }
    }
}
