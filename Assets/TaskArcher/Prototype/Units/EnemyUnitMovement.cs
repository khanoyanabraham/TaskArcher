using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskArcher.Scriptables;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class EnemyUnitMovement :  IMovement
    {
        private float _angle;
        private Rigidbody _rb;
        private UnitObject _unitObject;
        private Transform _transform;
        private float _distanceToStop = 1f;

        public EnemyUnitMovement(Transform transform, Rigidbody rb)
        {
            _transform = transform;
            _rb = rb;
        }    
        public void Move(Vector3 target, Vector3 velocity, float speed)
        {
            var localTarget = _transform.InverseTransformPoint(target).normalized;
            _angle = Mathf.Atan2(Mathf.Round(localTarget.x * 10f) * 0.1f, Mathf.Round(localTarget.y * 10f) * 0.1f) * Mathf.Rad2Deg;
            Vector3 eulerAngleVelocity = new Vector3(0, _angle, 0);
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);
            if (velocity.magnitude > 0.5)
            {
                if (Vector3.Distance(_transform.position, target) > _distanceToStop)
                {
                    var dir = (target - _transform.position).normalized;
                    _rb.velocity = dir * speed;
                }
                else
                {
                    _rb.velocity = Vector3.zero;
                }
            }
        }

        public void Move()
        {
         
        }
    }
}
