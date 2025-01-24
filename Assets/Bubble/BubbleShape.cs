using System;
using UnityEngine;
using UnityEngine.U2D;

public class BubbleShape : MonoBehaviour
{
    const float slpineOffset = 0.1f;

    [SerializeField] SpriteShapeController spriteShape;
    [SerializeField] Transform[] points;
    [SerializeField] float tangentMagnitude;

    void Awake()
    {
        UpdateVerticies();
    }

    void Update()
    {
        UpdateVerticies();
    }

    void UpdateVerticies()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 vertex = points[i].localPosition;
            Vector2 towardsCenter = -vertex.normalized;
            float colliderRadius = points[i].GetComponent<CircleCollider2D>().radius;

            try
            {
                spriteShape.spline.SetPosition(i, (vertex - towardsCenter * colliderRadius));
            }
            catch
            {
                spriteShape.spline.SetPosition(i, (vertex - towardsCenter * (colliderRadius + slpineOffset)));
            }

            Vector2 LTangent = spriteShape.spline.GetLeftTangent(i);
            Vector2 newRTangent = Vector2.Perpendicular(towardsCenter) * tangentMagnitude;
            Vector2 newLTangent = Vector2.zero - newRTangent;
            
            spriteShape.spline.SetLeftTangent(i, newLTangent);
            spriteShape.spline.SetRightTangent(i, newRTangent);
        }
    }
}
