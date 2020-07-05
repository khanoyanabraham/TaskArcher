using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskArcher.Prototype
{
    public interface IHealth
    {
        void Decrease(int damage);
        
    }
}
