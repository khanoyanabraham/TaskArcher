using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class BounceBullet : MonoBehaviour
    {
        public Rigidbody BulletBody;
        private Vector3 lastVelo;
        private Quaternion lastRotation;
        public int Damage;
        private void Start()
        {
            BulletBody.AddForce(BulletBody.transform.forward * 3, ForceMode.Impulse);
            lastVelo = BulletBody.velocity;

        }

        public void Update()
        {
            lastVelo = BulletBody.velocity;
            lastRotation = BulletBody.rotation;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var speed = lastVelo.magnitude;
            var direction = Vector3.Reflect(lastVelo.normalized, collision.contacts[0].normal);
            BulletBody.angularVelocity = Vector3.zero;
            BulletBody.velocity = direction * Mathf.Max(speed, 3f);
            BulletBody.rotation = Quaternion.Inverse(lastRotation);
        }
    }
}
