using System;
using System.Collections.Generic;

namespace MB.Softcrafts.DesignPattern.Observer
{
    public class Notification
    {
        internal Notification(int infoNumber, string from, int carousel)
        {
            this.InfoNumber = infoNumber;
            this.From = from;
            this.Carousel = carousel;
        }

        public int InfoNumber { get; }

        public string From { get; }

        public int Carousel { get; }
    }

    public class NotificationProvider : IObservable<Notification>
    {
        private readonly List<IObserver<Notification>> _observers;
        private readonly List<Notification> _infos;

        public NotificationProvider()
        {
            _observers = new List<IObserver<Notification>>();
            _infos = new List<Notification>();
        }

        public IDisposable Subscribe(IObserver<Notification> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                foreach (var item in _infos)
                    observer.OnNext(item);
            }
            return new Unsubscriber<Notification>(_observers, observer);
        }

        public void InfoStatus(int infoNr)
        {
            InfoStatus(infoNr, String.Empty, 0);
        }

        public void InfoStatus(int infoNr, string from, int office)
        {
            var info = new Notification(infoNr, from, office);


            if (office > 0 && !_infos.Contains(info))
            {
                _infos.Add(info);
                foreach (var observer in _observers)
                    observer.OnNext(info);
            }
            else if (office == 0)
            {

                var infosToRemove = new List<Notification>();
                foreach (var notification in _infos)
                {
                    if (info.InfoNumber == notification.InfoNumber)
                    {
                        infosToRemove.Add(notification);
                        foreach (var observer in _observers)
                            observer.OnNext(info);
                    }
                }
                foreach (var infoToRemove in infosToRemove)
                    _infos.Remove(infoToRemove);

                infosToRemove.Clear();
            }
        }

        public void LastNotificationClaimed()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();

            _observers.Clear();
        }
    }

    internal class Unsubscriber<T> : IDisposable
    {
        private readonly List<IObserver<T>> _observers;
        private readonly IObserver<T> _observer;

        internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }


    public class NotificationMonitor : IObserver<Notification>
    {
        private readonly string _name;
        private readonly List<string> _notificationInfos = new List<string>();
        public IDisposable Cancellation;
        private string fmt = "{0,-20} {1,5}  {2, 3}";

        public NotificationMonitor(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("The observer must be assigned a name.");

            this._name = name;
        }

        public virtual void Subscribe(NotificationProvider provider)
        {
            Cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            Cancellation.Dispose();
            _notificationInfos.Clear();
        }

        public virtual void OnCompleted()
        {
            _notificationInfos.Clear();
        }

        public virtual void OnError(Exception e)
        {
            // No implementation.
        }


        public virtual void OnNext(Notification notification)
        {
            bool updated = false;


            if (notification.Carousel == 0)
            {
                var infosToRemove = new List<string>();
                string infoNo = $"{notification.InfoNumber,5}";

                foreach (var info in _notificationInfos)
                {
                    if (info.Substring(21, 5).Equals(infoNo))
                    {
                        infosToRemove.Add(info);
                        updated = true;
                    }
                }
                foreach (var infoToRemove in infosToRemove)
                    _notificationInfos.Remove(infoToRemove);

                infosToRemove.Clear();
            }
            else
            {

                string notificationInfo = String.Format(fmt, notification.From, notification.InfoNumber, notification.Carousel);
                if (!_notificationInfos.Contains(notificationInfo))
                {
                    _notificationInfos.Add(notificationInfo);
                    updated = true;
                }
            }
            if (updated)
            {
                _notificationInfos.Sort();
                Console.WriteLine("Information: {0}", this._name);
                foreach (var info in _notificationInfos)
                    Console.WriteLine(info);

                Console.WriteLine();
            }
        }
    }


}
