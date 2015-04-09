using System;

namespace IoCNinject.Model
{
    public interface IMessageFormatter: IDisposable
    {
        string Format(string message);
    }
}