using System;

namespace MB.Softcrafts.DesignPattern.State
{
    public class StateA : IHandleStates
    {
        public void Change(Context context)
        {
            context.State = new StateB();
            Console.WriteLine("Change state from A to B.");
        }
    }
}