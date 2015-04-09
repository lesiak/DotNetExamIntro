using System;

namespace IoCNinject.Model
{
    public interface IClock: IDisposable
    {
        string GetCurrentDateTime();
    }
}