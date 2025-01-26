using Bubble;
using Cam;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityEvent onStartInflating;
    public UnityEvent onStopInflating;

    [SerializeField] GameObject bubblePrefab;
    [SerializeField] CameraFollow camFollow;
    [SerializeField] LayerMask bubbleLayer;

    Bubble.Bubble m_TargetBubble;
    
    // Called by event
    public void SpawnBubble(Vector2 screenPos)
    {
        if (CheckLayer(screenPos)) return;
        
        Instantiate(bubblePrefab, GetMousePosition(screenPos), Quaternion.identity);
    }

    // Called by event
    public void InflateBubble(Vector2 screenPos)
    {
        RaycastHit2D hit = CheckLayer(screenPos, bubbleLayer);

        if (!hit)
        {
            m_TargetBubble = null;
            onStopInflating?.Invoke();
            return;
        }

        if (m_TargetBubble == null)
        {
            m_TargetBubble = hit.transform.GetComponent<Bubble.Bubble>();
            onStartInflating?.Invoke();
        }
        else
            m_TargetBubble.Inflate();
    }

    public void StopInflateBubble()
    {
        m_TargetBubble = null;
        onStopInflating?.Invoke();
    }

    Vector2 GetMousePosition(Vector2 screenPos)
    {
        
        Vector3 screenWithOffset = new Vector3(screenPos.x, screenPos.y, -camFollow.offset.z); 
        Vector2 screenToWorld = camFollow.cam.ScreenToWorldPoint(screenWithOffset);
        return screenToWorld;
    }
    
    RaycastHit2D CheckLayer(Vector2 screenPos)
    {
        Ray ray = camFollow.cam.ScreenPointToRay(screenPos);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        return hit;
    }

    RaycastHit2D CheckLayer(Vector2 screenPos, LayerMask layer)
    {
        Ray ray = camFollow.cam.ScreenPointToRay(screenPos);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layer);

        return hit;
    }
}
