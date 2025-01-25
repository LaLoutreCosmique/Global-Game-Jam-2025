using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private GameObject[] bulles = new GameObject[1];
    [SerializeField] private GameObject bulle;
    //[SerializeField] private int _slotSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Spawning(GameObject bulleChoosen)
    {
        var actualBulle =Instantiate(bulleChoosen, GetMousePosition(), Quaternion.identity);
        Destroy(actualBulle, 3f);
    }

    
}
