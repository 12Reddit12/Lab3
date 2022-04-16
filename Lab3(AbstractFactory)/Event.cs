using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab3
{
    public delegate void EventDelegate();

    class Event
    {
        public event EventDelegate Installed = null;
        public event EventDelegate Uninstalled = null;
        public event EventDelegate Started = null;
        public event EventDelegate ErrorEv = null;

        public void InstallEvent()
        {
            Installed += GameInstalled;
            Installed.Invoke();
            Installed -= GameInstalled;
        }

        public void UninstallEvent()
        {
            Uninstalled += GameUnInstalled;
            Uninstalled.Invoke();
            Uninstalled -= GameUnInstalled;
        }
        public void StartEvent()
        {
            Started += GameStarted;
            Started.Invoke();
            Started -= GameStarted;
        }

        public void ErrorEvent()
        {
            ErrorEv += Error;
            ErrorEv.Invoke();
            ErrorEv -= Error;
        }

        static private void GameInstalled()
        {
            Console.WriteLine("Игра установлена . ");
            Thread.Sleep(1000);
        }

        static private void GameUnInstalled()
        {
            Console.WriteLine("Игра удалена . ");
            Thread.Sleep(1000);
        }

        static private void GameStarted()
        {
            Console.WriteLine("Игра начата . ");
            Thread.Sleep(1000);
        }

        static private void Error()
        {
            Console.WriteLine("Error . ");
            Thread.Sleep(1000);
        }
    }
}

