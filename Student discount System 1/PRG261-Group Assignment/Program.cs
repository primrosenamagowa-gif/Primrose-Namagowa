using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG261_Group_Assignment
{

    //Masego Morule -603119
    //Tsholanang Makgoka -602912
    //Makgotso Seopa -600673
    //Primrose Namagowa -603049
    //Ntlakuso Nkuna   -578028


    class Program
    {
        // this is the enum that will help us decided what the user wants to do.
        enum Menu
        {
            CaptureDetails= 1,
            CheckDiscountQualification,
            ShowQualificationStatus,
            Exit
        }


            // create collections to keep track of students.
            static List<Dictionary<string, string>> students = new List<Dictionary<string, string>>();
            static List<Dictionary<string, string>> qualifiedStudents = new List<Dictionary<string, string>>();
            static int deniedCount = 0;

            static void Main(string[] args)
            {
                Console.Title = "Belgium Campus Cafeteria Discount Program";
                bool running = true;

                while (running)
                {
                    // clear the screen for increased interactivity.
                    Console.Clear();
                    ShowHeader("Belgium Campus Discount Application");

                    Console.WriteLine("MAIN MENU:");
                    Console.WriteLine("[1] Capture Student Details");
                    Console.WriteLine("[2] Check Discount Qualification");
                    Console.WriteLine("[3] Show Qualification Summary");
                    Console.WriteLine("[4] Exit Program");
                    Console.Write("\nSelect an option by entering the number: ");

                    // here, we are using the user input to map it to the corresponding enum option.
                    if (Enum.TryParse(Console.ReadLine(), out Menu choice))
                    {
                        Console.Clear();
                        switch (choice)
                        {
                            case Menu.CaptureDetails:
                                ShowHeader("Capture Student Details");
                                CaptureDetails();
                                break;
                            case Menu.CheckDiscountQualification:
                                ShowHeader("Discount Qualification Evaluation");
                                CheckQualification();
                                break;
                            case Menu.ShowQualificationStatus:
                                ShowHeader("Qualification Summary");
                                ShowStatus();
                                break;
                            case Menu.Exit:
                                running = false;
                                Console.WriteLine("Exiting the program. Have a great day!");
                                break;
                        }
                    }
                    // then here, we will use the ShowError() method [it is defined somewhere at the bottom] to tell the user that they did not enter a correct option
                    else
                    {
                        ShowError("Invalid input. Please enter a valid number from the menu.");
                        // the pause method is also defined below.
                        Pause();
                    }
                }
            }

            // a method to capture the student details.
            // a lot of the functionality used in this method is defined below.
            public static void CaptureDetails()
        {
            string more = "Y";
            while (more.ToUpper() == "Y")
            {
                // since our students are stored in a list of dictionaries, we need to store each student in a dictionary.
                Dictionary<string, string> student = new Dictionary<string, string>();
                student["FullName"] = Prompt("Enter Full Name: ");
                // a ternary operator because why not?
                student["IsResidenceStudent"] = AskYesNo("Is the student a residence student? (Y/N): ") ? "Yes" : "No";
                student["YearsOnCampus"] = GetValidInt("Years on Campus: ").ToString();
                student["YearsAtCurrentResidence"] = GetValidInt("Years at Current Residence: ").ToString();
                student["MonthlyAllowance"] = GetValidDouble("Monthly Allowance or Salary (in Rands): ").ToString();
                student["AverageMark"] = GetValidDouble("Average Mark (%): ").ToString();
                // add the dictionary to the students colelctions => it is a list of dictionaries.
                students.Add(student);

                Console.WriteLine("\nStudent information captured successfully.");
                more = Prompt("\nDo you want to capture another student? (Y/N): ");
                Console.Clear();
                ShowHeader("Capture Student Details");
            }
        }

        // a method to see how many students qualified and how many did not.
        public static void CheckQualification()
        {
            qualifiedStudents.Clear();
            deniedCount = 0;

            if (students.Count == 0)
            {
                ShowError("No student records found. Please capture student details first.");
                Pause();
                return;
            }

            foreach (var student in students)
            {
                bool isResidence = student["IsResidenceStudent"] == "Yes";
                int yearsOnCampus = int.Parse(student["YearsOnCampus"]);
                double avgMark = double.Parse(student["AverageMark"]);
                double allowance = double.Parse(student["MonthlyAllowance"]);

                if (isResidence && yearsOnCampus > 1 && avgMark > 85 && allowance <= 1000)
                {
                    qualifiedStudents.Add(student);
                }
                else
                {
                    deniedCount++;
                }
            }

            Console.WriteLine("Evaluation complete.");
            Console.WriteLine($"Qualified Students: {qualifiedStudents.Count}");
            Console.WriteLine($"Denied Students: {deniedCount}");
            Pause();
        }

        // Get an overall summary of the students.
        public static void ShowStatus()
        {
            if (students.Count == 0)
            {
                ShowError("No student data available to display.");
                Pause();
                return;
            }

            Console.WriteLine("Summary of Student Discount Evaluation:\n");
            Console.WriteLine($"Total Students Captured: {students.Count}");
            Console.WriteLine($"Qualified for Discount : {qualifiedStudents.Count}");
            Console.WriteLine($"Did Not Qualify        : {deniedCount}");

            Console.WriteLine("\nAll Captured Student Details:\n");

            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                Console.WriteLine($"Student {i + 1}:");
                Console.WriteLine($"  Full Name           : {student["FullName"]}");
                Console.WriteLine($"  Residence Student   : {student["IsResidenceStudent"]}");
                Console.WriteLine($"  Years on Campus     : {student["YearsOnCampus"]}");
                Console.WriteLine($"  Years at Residence  : {student["YearsAtCurrentResidence"]}");
                Console.WriteLine($"  Monthly Allowance   : R{student["MonthlyAllowance"]}");
                Console.WriteLine($"  Average Mark        : {student["AverageMark"]}%");

                bool qualifies = student["IsResidenceStudent"] == "Yes" &&
                                 int.Parse(student["YearsOnCampus"]) > 1 &&
                                 double.Parse(student["AverageMark"]) > 85 &&
                                 double.Parse(student["MonthlyAllowance"]) <= 1000;

                Console.WriteLine($"  Qualifies for Discount: {(qualifies ? "Yes" : "No")}");
                Console.WriteLine(new string('-', 50));
            }

            Pause();
        }

        /* THE METHODS HERE ARE PURELY TO INCREASE USER INTERACTIVITY WITH THE CONSOLE APP. THEY ARE ALSO USED FOR GOOD CODE PRACTICES.
         * so, without further ado, let's go over them :)
         * 
         * the ShowHeader() method prints out whatever string we put in the argument so that it looks good.
         * the ShowError() method changes the font color to red, and is used whenever the user inputs invalid information.
         * the Pause() method basically works the same way that the C# compiler works when you're done executing the program. it waits for you to click a button before doing something.
         * the Prompt() method just prints out a message for the user and returns the user input
         * the AskYesNo() method maps "y" to true and "n" to false, and returns the respective boolean.
         * the GetValidInt() and GetValidDouble() methods just make sure that the user entered the correct datatype.
         */
        public static void ShowHeader(string title)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"  {title}");
            Console.WriteLine("--------------------------------------------------\n");
        }

        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

        public static string Prompt(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static bool AskYesNo(string message)
        {
            string input;
            while (true)
            {
                Console.Write(message);
                input = Console.ReadLine().Trim().ToUpper();
                if (input == "Y") return true;
                if (input == "N") return false;

                ShowError("Invalid input. Please enter Y for Yes or N for No.");
            }
        }

        public static int GetValidInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value)) return value;

                ShowError("Invalid number. Please enter a valid integer.");
            }
        }

        public static double GetValidDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value)) return value;

                ShowError("Invalid input. Please enter a valid number.");
            }



        }
    
    }

}
