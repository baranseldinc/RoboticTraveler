using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticTraveler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Top-Right coordinates of the Mars Surface: ");
            string surfaceTopRight = Console.ReadLine();
            Surface surface = new Surface(surfaceTopRight);
            Console.WriteLine();

            Console.Write("Enter the status of Robot1: ");
            string robot1Status = Console.ReadLine();
            RoboticTraveler robot1 = new RoboticTraveler(robot1Status, surface);
            Console.Write("Enter the actions of Robot1: ");
            string robot1Actions = Console.ReadLine();
            robot1.TakeActions(robot1Actions);
            Console.WriteLine();

            Console.Write("Enter the status of Robot2: ");
            string robot2Status = Console.ReadLine();
            RoboticTraveler robot2 = new RoboticTraveler(robot2Status, surface);
            Console.Write("Enter the actions of Robot2: ");
            string robot2Actions = Console.ReadLine();
            robot2.TakeActions(robot2Actions);
            Console.WriteLine();

            Console.WriteLine("The last status of Robot1: " + robot1.GetOutputLocation());
            Console.WriteLine("The last status of Robot2: " + robot2.GetOutputLocation());

            Console.ReadKey();
        }
    }
}
