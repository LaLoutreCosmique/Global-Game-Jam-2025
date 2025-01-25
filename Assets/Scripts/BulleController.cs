using UnityEngine;

public class BulleController : MonoBehaviour
{
    private Vector2 _moveUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _moveUp, -0.30f*Time.deltaTime);
    }
}
