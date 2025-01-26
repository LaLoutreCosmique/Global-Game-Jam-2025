using UnityEngine;

public class Parallaxe : MonoBehaviour
{
    public GameObject camera;
    public float parallaxeEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceX = camera.transform.position.x * parallaxeEffect;
        float distanceY = camera.transform.position.y * parallaxeEffect;

        transform.position = new Vector3(distanceX, distanceY, transform.position.z);
    }
}
