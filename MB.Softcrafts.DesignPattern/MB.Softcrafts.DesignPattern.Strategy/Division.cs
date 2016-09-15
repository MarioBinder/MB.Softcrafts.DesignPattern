namespace MB.Softcrafts.DesignPattern.Strategy
{
    public class Division : IStrategy
    {
        public int Arithmetic(int a, int b)
        {
            return a / b;
        }
    }
}