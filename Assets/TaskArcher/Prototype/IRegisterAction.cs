using System;
using TaskArcher.Prototype.Actions;

namespace TaskArcher.Prototype
{
    public interface IRegisterAction
    {
       void RegisterActionSig(ActionSig actsignal, Action action);
      
    }
}
