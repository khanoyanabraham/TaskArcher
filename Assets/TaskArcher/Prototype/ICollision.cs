using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskArcher.Prototype
{
    public interface ICollision
    {
        void OnCollistionEnter(Collision col);
        void OnCollostionStay(Collision col);
      
    }
}
