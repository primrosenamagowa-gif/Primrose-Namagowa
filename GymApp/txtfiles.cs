using System;
using System.IO;

namespace GymApp
{
    public class UserManager
    {
        private string _directoryPath;

        public UserManager(string directoryPath)
        {
            _directoryPath = directoryPath;


            try
            {
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
        }

        public void SaveUser(string username, string password)
        {
            try
            {
                string fileName = $"{Guid.NewGuid()}.txt";
                string filePath = Path.Combine(_directoryPath, fileName);

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine($"Username: {username}");
                    sw.WriteLine($"Password: {password}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error saving user: {ex.Message}");
            }
        }

        public bool UserExists(string username)
        {
            try
            {
                var files = Directory.GetFiles(_directoryPath, "*.txt");

                foreach (var file in files)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.StartsWith("Username: ") && line.Substring(10) == username)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error checking user: {ex.Message}");
            }
            return false;
        }

        public bool VerifyUser(string username, string password)
        {
            try
            {
                var files = Directory.GetFiles(_directoryPath, "*.txt");

                foreach (var file in files)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        string line;
                        string fileUsername = null;
                        string filePassword = null;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.StartsWith("Username: "))
                            {
                                fileUsername = line.Substring(10);
                            }
                            else if (line.StartsWith("Password: "))
                            {
                                filePassword = line.Substring(10);
                            }

                            if (fileUsername == username && filePassword == password)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error verifying user: {ex.Message}");
            }
            return false;
        }
    }
}
