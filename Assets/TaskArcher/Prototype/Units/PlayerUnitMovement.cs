using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskArcher.Scriptables;
using UnityEngine;

namespace TaskArcher.Prototype.Units
{
    public class PlayerUnitMovement : IMovement
    {
        private UnitObject _params;
        private Rigidbody _rb;
        private Vector3 anglevelocity;
        public Plane groundPlane;
        public PlayerUnitMovement(Rigidbody rb,UnitObject param)
        {
            _rb = rb;
            _params = param;
        }
        public void Move()
        {
            _rb.angularVelocity = UnityEngine.Vector3.zero;
            var deltaRotation = Quaternion.Euler(anglevelocity * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                anglevelocity = new Vector3(0, -150*_params.Speed, 0);
                _rb.MoveRotation(_rb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.D))
            {
                anglevelocity = new Vector3(0, 150*_params.Speed, 0);
                _rb.MoveRotation(_rb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.W))
            {
                _rb.velocity = _rb.rotation * (Vector3.forward * _params.Speed);
            }
        }
    }
}
