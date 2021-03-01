using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace x1
{
    class Timer
    {
        readonly DispatcherTimer dispatcherTimer;
        readonly Func<bool> Func;

        public static void StartTimer(TimeSpan timeSpan, Func<bool> func)
            => new Timer(timeSpan, func);


        public Timer(TimeSpan span, Func<bool> func)
        {
            Func = func;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = span;
            dispatcherTimer.Start();
        }

        void DispatcherTimer_Tick(object sender, object e)
        {
            if (!Func.Invoke())
            {
                dispatcherTimer.Stop();
            }
        }
    }
}
