using TaskArcher.Prototype.Actions;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class EnemyUnitCollision : ICollision
    {
       private Rigidbody _rb;
        public ActionSigGen<int> DamageReceived = new ActionSigGen<int>();
        private PlayerUnit _unit;
        public EnemyUnitCollision(Rigidbody rb,PlayerUnit unit)
        {
            _unit = unit;
               _rb = rb;
        }
        public void OnCollistionEnter(Collision col)
        {
            if (col.gameObject.name == "PlayerBullet")
            {
                DamageReceived?.Dispatch(_unit.ScriptObject.Damage);
            }
            _rb.angularVelocity = Vector3.zero;
        }

        public void OnCollostionStay(Collision col)
        {
            _rb.angularVelocity = Vector3.zero;
        }
    }
}
