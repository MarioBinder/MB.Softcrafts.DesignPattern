namespace MB.Softcrafts.DesignPattern.Strategy
{
    public class Subtract : IStrategy
    {
        public int Arithmetic(int a, int b)
        {
            return a - b;
        }
    }
}