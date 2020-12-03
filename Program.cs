using Client.Solutions;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var data = await ORM.ReadDataAsync();

            ThirdAdvent.Solve(data);

            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
    }
}
