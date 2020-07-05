using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskArcher.Prototype.Utils
{
    public class CameraFollow : MonoBehaviour
    {
        private GameObject player;
        public float smoothTime = 0.3f;
        private Vector3 velocity = Vector3.zero;
        public Vector3 boundsMax;
        public Vector3 boundsMin;

        private void Start()
        {
            player = GameObject.Find("Player");
        }
        void Update()
        {

            if (player != null)
            {
                Vector3 goalPos = player.transform.position;
                transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, 4.4f, 4.4f), transform.position.y, transform.position.z);

            }
        }
    }
}
