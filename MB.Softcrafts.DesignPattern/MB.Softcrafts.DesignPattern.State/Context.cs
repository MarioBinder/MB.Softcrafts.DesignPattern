using System;

namespace MB.Softcrafts.DesignPattern.State
{
    public class Context
    {   
        public IHandleStates State { get; set; }

        public Context(IHandleStates state)
        {
            State = state;
            Console.WriteLine("Create object of context class with initial State.");
        }

        public void Request()
        {
            State.Change(this);
        }
    }
}