using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody BulletBody;
        public int Damage;
        private void Start()
        {
            BulletBody.AddForce(BulletBody.transform.forward * 3, ForceMode.Impulse);
          
        }


        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
