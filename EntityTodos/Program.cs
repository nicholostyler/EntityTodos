using System;
using System.Linq;
using TodoLibrary.Data;
using TodoLibrary.Models;

namespace EntityTodos
{
    class Program
    {
        private static TaskContext _context = new TaskContext();

        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            Console.WriteLine("Hello World!");
            PrintMenu();
        }

        private static void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1: Add a task to the database.");
                Console.WriteLine("2: Retrieve task(s) from the database.");
                Console.WriteLine("3: Remove a task to the database.");

                Console.Write("Type in the menu item you want q to quit: ");

                switch (Console.ReadLine())
                {
                    case ("1"):
                        AddTask();
                        break;
                    case ("2"):
                        RetrieveTasks();
                        break;
                    case ("3"):
                        RemoveTask();
                        break;
                    case ("q"):
                        return;
                    default:
                        break;
                }
            }
        }

        private static void RemoveTask()
        {
            string input = string.Empty;
            int selectedTaskId = 0;
            Task selectedTask = new Task();

            Console.Write("Enter in the id of the task you wish to remove: ");

            try
            {
                input = Console.ReadLine();
                selectedTaskId = int.Parse(input);
            }
            catch(FormatException e)
            {
                Console.WriteLine("You did not enter a valid id");
                Console.WriteLine(e.Message);
            }

            int successful = _context.SaveChanges();

            if (successful > 0) Console.WriteLine("Succesfully deleted task!");
        }

        private static void AddTask()
        {
            string input = string.Empty;
            Task newTask = new Task();

            Console.Write("Enter in the tasks description: ");
            input = Console.ReadLine();

            newTask.Description = input;
            _context.Tasks.Add(newTask);
            int successful = _context.SaveChanges();

            if (successful > 0) Console.WriteLine("Succesfully added task!");
        }

        private static void RetrieveTasks()
        {
            string input = string.Empty;
            int selectedIndex = 0;

            Console.Write("Enter the id of the task you wish to view. Enter a for all: ");
            input = Console.ReadLine();
            if (input == "a")
            {
                var tasks = _context.Tasks.ToList();
                Console.WriteLine($"\nTask count is {tasks.Count}");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"{task.Id}: {task.Description}");
                }
            }
            else
            {
                try
                {
                    selectedIndex = int.Parse(input);
                    var selectedTask = _context.Tasks.Find(selectedIndex);
                }
                catch(FormatException e)
                {
                    Console.WriteLine("You did not enter in a valid id.");
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
