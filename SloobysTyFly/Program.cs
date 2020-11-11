using System;
using System.Threading;
using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Helpers;
using System.Linq;

namespace SloobysTyFly
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("sloobs ty fly");
            Console.WriteLine("toggling fly!");
            new Thread(() =>
            {
                while (true)
                {
                    using (var m = new MemorySharp(ApplicationFinder.FromProcessName("TY2").First()))
                    {
                        var jumpPointer = new IntPtr(0x004465EC);
                        int[] offsets = { 0x3C, 0x3C, 0x238, 0x54, 0xDC, 0x4 };

                        jumpPointer = m[jumpPointer].Read<IntPtr>();
                        jumpPointer = m[jumpPointer + offsets[0], false].Read<IntPtr>();
                        jumpPointer = m[jumpPointer + offsets[1], false].Read<IntPtr>();
                        jumpPointer = m[jumpPointer + offsets[2], false].Read<IntPtr>();
                        jumpPointer = m[jumpPointer + offsets[3], false].Read<IntPtr>();
                        jumpPointer = m[jumpPointer + offsets[4], false].Read<IntPtr>();

                        m[jumpPointer + offsets[5], false].Write(1);

                        Thread.Sleep(50);
                    }
                }
            }).Start();
        }
    }
}
