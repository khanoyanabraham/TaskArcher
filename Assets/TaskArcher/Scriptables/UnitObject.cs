using Assets.TaskArcher.UnitEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskArcher.Scriptables
{
    [CreateAssetMenu(fileName = "Unit", menuName = "TaskArcher/Unit", order = 1)]
    public class UnitObject : ScriptableObject
    {
        public LayerMask mask;
        public int Health;
        public int Damage;
        public Weapon Weapon;
        public float Speed;
        public float FireRate;
    }
}
