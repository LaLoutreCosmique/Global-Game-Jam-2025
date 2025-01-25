using UnityEngine;

namespace Obstacles
{
    public class ForceField : MonoBehaviour
    {
        [SerializeField] float force;

        public float Force => force;
    }
}
