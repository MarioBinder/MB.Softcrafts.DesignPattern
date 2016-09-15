namespace MB.Softcrafts.DesignPattern.Strategy
{
    public class Multiplication : IStrategy
    {
        public int Arithmetic(int a, int b)
        {
            return a * b;
        }
    }
}