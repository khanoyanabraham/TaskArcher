using TaskArcher.Prototype.Actions;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class PlayerUnitCollision : ICollision
    {
        public ActionSigGen<int> DamageReceived = new ActionSigGen<int>();
        public void OnCollistionEnter(Collision col)
        {
            if (col.gameObject.name == "EnemyBullet")
            {
                var bullet=  col.gameObject.GetComponent<Bullet>();
                DamageReceived?.Dispatch(bullet.Damage);
            }
        }

        public void OnCollostionStay(Collision col)
        {

        }
    }
}
