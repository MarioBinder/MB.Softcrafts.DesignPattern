using System;

namespace MB.Softcrafts.DesignPattern.State
{
    public class StateB : IHandleStates
    {
        public void Change(Context context)
        {
            context.State = new StateC();
            Console.WriteLine("Change state from B to C.");
        }
    }
}