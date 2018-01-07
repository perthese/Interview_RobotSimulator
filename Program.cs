using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyMovingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose option to create robot:");
            Console.WriteLine("   1     : Create robot randomly");
            Console.WriteLine("   2     : Create robot from file");
            Console.WriteLine("   Others: QUIT PROGRAM");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    RandomRobot();
                    break;
                case "2":
                    Console.WriteLine("Please choose file to run the robot:");
                    Console.WriteLine("   1: Test1.txt");
                    Console.WriteLine("   2: Test2.txt");
                    Console.WriteLine("   3: Test3.txt");
                    Console.WriteLine("   4: Test4.txt");
                    Console.WriteLine("   5: File path");
                    Console.WriteLine("   Others: QUIT PROGRAM");
                    var fileID = Console.ReadLine();
                    var filePath = String.Empty;
                    switch (fileID)
                    {
                        case "1":
                            filePath = "Test1.txt";
                            break;
                        case "2":
                            filePath = "Test2.txt";
                            break;
                        case "3":
                            filePath = "Test3.txt";
                            break;
                        case "4":
                            filePath = "Test4.txt";
                            break;
                        case "5":
                            filePath = fileID;
                            break;
                    }
                    if (filePath.Length > 0)
                        ReadFromFile(filePath);

                    break;

            }
            Console.ReadLine();
        }

        static void RandomRobot()
        {
            Random random = new Random();
            int rows = random.Next(1, 10);
            int cols = random.Next(1, 10);

            int x = random.Next(0, rows - 1);
            int y = random.Next(0, cols - 1);


            var direction = Helper.GetRandomDirection();

            Robot robot = new Robot(new Dimension(rows, cols), new Position(x, y), direction);

            robot.Move();
            robot.SetDirection(Helper.GetRandomNewDirection(direction));
            robot.Move();
            robot.Print();

            robot.PrintHistory();

            Console.ReadLine();
        }




        static void ReadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    var lines = File.ReadAllLines(filePath);

                    Robot robot = null;

                    foreach (var line in lines)
                    {

                        string[] items = line.Trim().Split(' ');
                        if (items.Length > 1)
                        {
                            if (items[0].ToUpper() == "PLACE")
                            {
                                var parameters = items[1].Split(',');
                                if (parameters.Length > 2)
                                {
                                    try
                                    {
                                        var x = Convert.ToInt32(parameters[0].Trim());
                                        var y = Convert.ToInt32(parameters[1].Trim());
                                        var directionString = parameters[2].Trim();
                                        Direction direction=Direction.None;
                                        switch (directionString)
                                        {
                                            case "EAST":
                                                direction = Direction.East;
                                                break;
                                            case "WEST":
                                                direction = Direction.West;
                                                break;
                                            case "NORTH":
                                                direction = Direction.North;
                                                break;
                                            case "SOUTH":
                                                direction = Direction.South;
                                                break;
                                        }
                                        if(direction != Direction.None)
                                            robot = new Robot(x, y, direction);
                                    }
                                    catch
                                    {

                                    }
                                }


                            }


                        }
                        else if (robot != null)
                        {
                            switch (line.Trim())
                            {
                                case "MOVE":
                                    robot.Move();
                                    break;

                                case "REPORT":
                                    robot.Print();
                                    robot.PrintHistory();
                                    break;

                                case "LEFT":
                                    var currentDirection = robot.GetDirection();
                                    var newDirection = (Direction)((Convert.ToInt32(currentDirection) + 1)%4);
                                    robot.SetDirection(newDirection);
                                    break;

                                case "RIGHT":
                                    var currentdirection = robot.GetDirection();
                                    var newdirection = (Direction)((Convert.ToInt32(currentdirection) - 1)%4);
                                    robot.SetDirection(newdirection);
                                    break;

                            }

                        }
                    }

                    if (robot == null)
                    {
                        Console.WriteLine("Invalid setting for robot. Please check file content to create robot with PLACE command!");
                    }
                }
                catch
                {
                    Console.WriteLine("Error Reading File...");
                }
                // Console.WriteLine("Reading File...");
            }
            else
            {
                Console.WriteLine("Invalid File Path");
            }
        }
    }
}
