using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Spawners
{
    [RequireComponent(typeof(BoxcastCommand))]
    public class SpawnerVolunes : MonoBehaviour
    {
        private BoxCollider Collider;

        // Start is called before the first frame update
        void Awake()
        {
            Collider = GetComponent<BoxCollider>();
        }

        public Vector3 GetPositionInBounds()
        {
            var bounds = Collider.bounds;
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                transform.position.y,
                Random.Range(bounds.min.z, bounds.max.z)
                );
        }
    }
}

