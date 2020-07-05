using TaskArcher.Prototype.Actions;
using TaskArcher.Scriptables;

namespace TaskArcher.Prototype.Units
{
    public class EnemyUnitHealth : IHealth
    {
        public ActionSig deathSignal = new ActionSig();
        private UnitObject _enemyParam;
        public EnemyUnitHealth(UnitObject enemyParam)
        {
            _enemyParam = enemyParam;
        }
        public void Decrease(int damage)
        {
            _enemyParam.Health = _enemyParam.Health - damage;
            if (_enemyParam.Health <= 0)
            {
                deathSignal?.Dispatch();
            }
        }
    }
}
