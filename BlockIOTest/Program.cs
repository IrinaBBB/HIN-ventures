using System;
using BlockIoLib;

namespace BlockIOTest
{
    class Program
    {
        private static readonly BlockIo _blockIo = new("9da8-f106-e0c7-e733", "H5sbN8Ra34KjgaTFEBcN"); //"DOGECOIN"
        static void Main(string[] args)
        {
            var data = _blockIo.GetBalance().Data;
            Console.WriteLine(data.ToString());
            Console.ReadLine();
        }
    }
}
