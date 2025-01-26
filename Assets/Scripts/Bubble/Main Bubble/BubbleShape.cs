using UnityEngine;
using UnityEngine.U2D;

namespace Bubble.MainBubble
{
    public class MainBubbleShape : MonoBehaviour
    {
        const float slpineOffset = 0.1f;

        [SerializeField] SpriteShapeController spriteShape;
        [SerializeField] Transform[] points;
        [SerializeField] float tangentMagnitude;
        [SerializeField] float offset;

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
                    spriteShape.spline.SetPosition(i, vertex - towardsCenter * (colliderRadius - offset));
                }
                catch
                {
                    spriteShape.spline.SetPosition(i, (vertex - towardsCenter * (colliderRadius - offset + slpineOffset)));
                }

                Vector2 newRTangent = Vector2.Perpendicular(towardsCenter) * tangentMagnitude;
                Vector2 newLTangent = Vector2.zero - newRTangent;
            
                spriteShape.spline.SetLeftTangent(i, newLTangent);
                spriteShape.spline.SetRightTangent(i, newRTangent);
            }
        }
    }
}
