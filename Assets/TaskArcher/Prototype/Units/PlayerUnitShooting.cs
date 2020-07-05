using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using TaskArcher.Scriptables;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class PlayerUnitShooting : IShooting
    {
        private UnitObject _param;
        private Transform _bowTransform;
        private Bullet _bullets;
        private float lastShoot;
        public PlayerUnitShooting(Bullet bullet, Transform bowTransform, UnitObject obj)
        {
            _param = obj;

            _bullets = bullet;
            _bowTransform = bowTransform;
        }

        public void Shoot()
        {
            if (Time.time > _param.FireRate + lastShoot)
            {
                var bull =GameObject.Instantiate(_bullets, _bowTransform.position, _bowTransform.rotation);
                bull.name = "PlayerBullet";
                bull.Damage = _param.Damage;
                lastShoot = Time.time;
            }
        
        }
    }
}
