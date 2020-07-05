using TaskArcher.Prototype.Actions;
using TaskArcher.Scriptables;

namespace TaskArcher.Prototype.Units
{
    public class PlayerUnitHealth : IHealth
    {
        public ActionSig deathSignal = new ActionSig();
        private UnitObject _obj;
        public PlayerUnitHealth(UnitObject obj)
        {
            _obj = obj;
        }
        public void Decrease(int damage)
        {
            _obj.Health = _obj.Health - damage;
            if (_obj.Health <= 0)
            {
                deathSignal?.Dispatch();
            }
        }
    }
}
