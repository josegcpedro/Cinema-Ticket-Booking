using System;
using dotenv.net;

class Program{
    static void Main()
    {
        LoginMenu();
    }
    static void LoginMenu()
    {
        Console.WriteLine("Bienvenue dans notre cinema!");
        Console.WriteLine("1. Admin");
        Console.WriteLine("2. Visiteur");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AdminLogin();
                break;
            case "2":
                //GuessMenu();
                break;
        }
    }
    static void AdminLogin(){
        Console.WriteLine("Identifiez-vous!");
        DotEnv.Load();

        string? password = Console.ReadLine();
        string? verificationPassword = Environment.GetEnvironmentVariable("password");
            if (password != verificationPassword)
            {
                Console.WriteLine("Mot de passe incorrect");
            }
            else
            {
                Console.WriteLine("Mot de passe correct");
                //AdminMenu();
                return;
            }
    }
}

class Films{
    string Name {get; set;}
    int Price {get; set;}
    string Description {get; set;}
    string Category {get; set;}
}
