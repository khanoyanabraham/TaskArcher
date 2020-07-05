using System;

namespace TaskArcher.Prototype.Actions
{
    public class ActionSigContainer :IRegisterAction
    {
        public void RegisterActionSig(ActionSig signal, Action action)
        {
            signal.AddAction(action);
        }

     

        public void RegisterActionSigGen<T>(ActionSigGen<T> signal, Action<T> action)
        {
            signal.AddAction(action);
        }

        
    }
}
