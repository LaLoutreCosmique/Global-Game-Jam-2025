using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private GameObject[] bulles = new GameObject[1];
    [SerializeField] private GameObject bulle;
    //[SerializeField] private int _slotSelected;

    void Awake()
    {
        
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            //_slotSelected = 0; Remplacer par la méthode pour savoir quel bulle le joueur à choisi
            Spawning(bulle);
            
        }
    }
    
    private Vector2 GetMousePosition()
    {
        return UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Spawning(GameObject bulleChoosen)
    {
        var actualBulle = Instantiate(bulleChoosen, GetMousePosition(), Quaternion.identity);
        Destroy(actualBulle, 3f);
    }

    
}
