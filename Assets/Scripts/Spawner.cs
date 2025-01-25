using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private GameObject[] bulles = new GameObject[1];
    [SerializeField] GameObject bubble;
    //[SerializeField] private int _slotSelected;
    
    
    
    Vector2 GetMousePosition(Vector2 screenPos)
    {
        //return UnityEngine.Camera.main.ScreenToWorldPoint(screenPos);
        return Vector2.zero;
    }

    // Called by event
    public void SpawnBubble(Vector2 screenPos)
    {
        var currentBubble = Instantiate(bubble, GetMousePosition(screenPos), Quaternion.identity);
    }

    
}
