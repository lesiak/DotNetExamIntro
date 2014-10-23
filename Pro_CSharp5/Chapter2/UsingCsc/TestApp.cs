using System;


class TestApp
{
    static void Main()
    {
        
        Console.WriteLine("Hello world");
        MessageBox.Show("Hello world");

        HelloMessage h = new HelloMessage();
        h.Speak();
    }
}

