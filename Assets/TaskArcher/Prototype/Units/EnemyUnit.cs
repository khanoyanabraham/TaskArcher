using System;
using TaskArcher.Scriptables;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class EnemyUnit : UnitBase<EnemyUnitMovement, EnemyUnitShooting, EnemyUnitCollision, EnemyUnitHealth>
    {
        public UnitObject ScriptObject;
        public Transform BowTransform;
        private PlayerUnit _player;
        private Rigidbody _playerRigidBody;
        private Rigidbody _rb;
        private Bullet _bullet;
        protected override void ActionSigRegistration()
        {
            ActioSigStorage.RegisterActionSig(Health.deathSignal, OnDead);
            ActioSigStorage.RegisterActionSigGen(Collision.DamageReceived, Health.Decrease);
        }

        private void OnDead()
        {
            Destroy(gameObject);
        }

        protected override void FixedUpdate()
        {
            if (_player != null)
            {
                Movement.Move(_player.transform.position, _playerRigidBody.velocity, ScriptObject.Speed);
                if (_playerRigidBody.velocity.magnitude < 0.5f && Vector3.Distance(transform.position, _player.transform.position) < 2f)
                {
                    Shooting.Shoot();
                }
            }
        }
        public void OnCollisionStay(Collision collision)
        {
            Collision.OnCollostionStay(collision);
        }
        protected override void OnCollisionEnter(Collision collision)
        {
            Collision.OnCollistionEnter(collision);
        }
        protected override void Initialize()
        {
            _bullet = Resources.Load<Bullet>("Bullet");
            _player = GameObject.FindWithTag("Player").GetComponent<PlayerUnit>();
            _playerRigidBody = _player.GetComponent<Rigidbody>();
            _rb = GetComponent<Rigidbody>();
            Init(new EnemyUnitMovement(transform, _rb), new EnemyUnitShooting(_bullet, BowTransform, ScriptObject), new EnemyUnitHealth(ScriptObject), new EnemyUnitCollision(_rb, _player));
        }
    }
}
