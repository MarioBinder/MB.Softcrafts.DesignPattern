using System;

namespace MB.Softcrafts.DesignPattern.State
{
    public class StateC: IHandleStates
    {
        public void Change(Context context)
        {
            context.State = new StateA();
            Console.WriteLine("Change state from C to A.");
        }
    }
}