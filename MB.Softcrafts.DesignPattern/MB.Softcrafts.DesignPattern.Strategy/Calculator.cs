namespace MB.Softcrafts.DesignPattern.Strategy
{
    public class Calculator
    {
        private readonly IStrategy _iStrategy;

        public Calculator(IStrategy iStrategy)
        {
            _iStrategy = iStrategy;
        }

        public int Calculate(int a, int b)
        {
            return _iStrategy.Arithmetic(a, b);
        }
    }
}