namespace MB.Softcrafts.DesignPattern.Strategy
{
    public class Addition : IStrategy
    {
        public int Arithmetic(int a, int b)
        {
            return a + b;
        }
    }
}