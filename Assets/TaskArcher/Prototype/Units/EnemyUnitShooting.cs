using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskArcher.Scriptables;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class EnemyUnitShooting :  IShooting
    {
        private UnitObject _param;
        private Transform _bowTransform;
        private Bullet _bullets;
        private float lastShoot;
        public EnemyUnitShooting(Bullet bullet, Transform bowTransform, UnitObject obj)
        {
            _param = obj;

            _bullets = bullet;
            _bowTransform = bowTransform;

        }
        public void Shoot()
        {
            if (Time.time > _param.FireRate + lastShoot)
            {
               var bull= GameObject.Instantiate(_bullets, _bowTransform.position, _bowTransform.rotation);
                bull.name = "EnemyBullet";
                bull.Damage = _param.Damage;
                lastShoot = Time.time;
            }
        }
    }
}
