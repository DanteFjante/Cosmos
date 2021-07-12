using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject objectToFollow;

        public Vector2 offset;

        public void Start()
        {
            if (objectToFollow == null)
                enabled = false;
        }

        public void Update()
        {
            var position = objectToFollow.transform.position;
            transform.position = new Vector3(
                position.x + offset.x, 
                position.y + offset.y,
                transform.position.z);
        }
    }
}