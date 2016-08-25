using System;

namespace PortalTest
{

    class CommandlineUi
    {
        public void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }


        public void HandleError(string message, Exception ex)
        {
            Console.WriteLine(message);
        }


        public Tuple<int,int> ReadNumbers()
        {
            return new Tuple<int, int>(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        }
    }

}