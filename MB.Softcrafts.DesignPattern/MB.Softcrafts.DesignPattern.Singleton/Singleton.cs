using System;

namespace MB.Softcrafts.DesignPattern.Singleton
{

    public sealed class Singleton2
    {
        private static readonly Lazy<Singleton2> _lazy =new Lazy<Singleton2>(() => new Singleton2());

        public static Singleton2 Instance => _lazy.Value;

        private Singleton2()
        {
        }
    }


    public class Singleton1
    {
        private static Singleton1 _instance;
        private Singleton1()
        {
        }
        public static Singleton1 Instance => _instance ?? (_instance = new Singleton1());
    }
}
