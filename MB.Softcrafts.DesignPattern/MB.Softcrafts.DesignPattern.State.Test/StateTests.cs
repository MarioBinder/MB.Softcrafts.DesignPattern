using NUnit.Framework;

namespace MB.Softcrafts.DesignPattern.State.Test
{
    [TestFixture]
    public class StateTests
    {
        [Test]
        public void StateATest()
        {
            var ctx = new Context(new StateA());
            ctx.Request();
            ctx.Request();
            ctx.Request();
        }
    }
}
