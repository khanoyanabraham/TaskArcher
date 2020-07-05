using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskArcher.Prototype.Actions
{
    public class ActionSig
    {
        private List<Action> _actions = new List<Action>();

        public void Dispatch()
        {
            _actions.ForEach(action => action?.Invoke());
        }

        public void AddAction(Action action)
        {
            _actions.Add(action);
        }

        public void RemoveAllActions()
        {
            _actions.Clear();
        }
    }
}
