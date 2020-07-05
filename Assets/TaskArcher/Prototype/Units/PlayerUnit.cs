using TaskArcher.Scriptables;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class PlayerUnit : UnitBase<PlayerUnitMovement, PlayerUnitShooting, PlayerUnitCollision, PlayerUnitHealth>
    {
        public UnitObject ScriptObject;
        private Rigidbody _rb;
        public Transform BowTransform;
        private Bullet _bullet;
        protected override void ActionSigRegistration()
        {
            ActioSigStorage.RegisterActionSig(Health.deathSignal, OnDead);
             ActioSigStorage.RegisterActionSigGen(Collision.DamageReceived, Health.Decrease);
        }
        protected override void FixedUpdate()
        {
            if (_rb.velocity.magnitude < 1)
            {
                Shooting.Shoot();
            }
            Movement.Move();
        }
        private void OnDead()
        {
            Destroy(gameObject);
        }
        protected override void OnCollisionEnter(Collision collision)
        {
            Collision.OnCollistionEnter(collision);
        }
        protected override void Initialize()
        {

            _bullet = Resources.Load<Bullet>("Bullet");
            _rb = GetComponent<Rigidbody>();
            Init(new PlayerUnitMovement(_rb, ScriptObject), new PlayerUnitShooting(_bullet, BowTransform, ScriptObject), new PlayerUnitHealth(ScriptObject), new PlayerUnitCollision());
        }
    }
}
