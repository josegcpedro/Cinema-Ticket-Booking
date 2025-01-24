using System;
using dotenv.net;

class Program{
    static List<Movie> movies = new List<Movie>
    {
        new Movie("Hulk", 20, "Hulk va devoir affronter un nouveau ennemi: Keito Gerber, qui a une arme très puissante: caffé latté.", "Fiction Scientifique", new DateTime(2025, 1, 25, 18, 30, 0)),
        
        new Movie("Inception", 25, "Un film sur les rêves dans les rêves.", "Science-fiction", new DateTime(2025, 1, 25, 20, 00, 0)),
        
        new Movie("Titanic", 15, "Une histoire d'amour épique qui se termine en tragédie.", "Drame", new DateTime(2025, 1, 26, 14, 00, 0)),
        
        new Movie("Amélie", 18, "Une jeune femme qui décide de rendre les gens heureux en secret.", "Comédie", new DateTime(2025, 1, 26, 16, 30, 0)),
        
        new Movie("Le Seigneur des Anneaux", 22, "Un hobbit et ses amis doivent détruire un anneau maléfique pour sauver le monde.", "Fantasy", new DateTime(2025, 1, 26, 19, 00, 0)),
        
        new Movie("La La Land", 20, "Un musicien et une actrice tombent amoureux à Los Angeles, mais leurs rêves les séparent.", "Musical", new DateTime(2025, 1, 27, 10, 30, 0)),
        
        new Movie("Le Fabuleux Destin d'Amélie Poulain", 17, "Une jeune femme décide de changer la vie de ceux qui l'entourent de manière mystérieuse.", "Romance", new DateTime(2025, 1, 27, 13, 30, 0)),
        
        new Movie("Gladiator", 21, "Un général romain devenu esclave cherche à venger la mort de sa famille.", "Drame", new DateTime(2025, 1, 27, 16, 00, 0))
    };

    static void Main()
    {
        LoginMenu();
    }

    static void LoginMenu()
    {
        Console.WriteLine("Bienvenue dans notre cinéma!");
        Console.WriteLine("1. Admin");
        Console.WriteLine("2. Visiteur");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AdminLogin();
                break;
            case "2":
                GuessMenu();
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
            Console.WriteLine("Mot de passe incorrect. Réessayez.");
            AdminLogin();
        }
        else
        {
            AdminMenu();
            return;
        }
    }

    static void AdminMenu(){
        Console.WriteLine("1. Ajouter un Nouveau film");
        Console.WriteLine("2. Voir les films disponibles");
        Console.WriteLine("3. Quitter");
        string? choice = Console.ReadLine();

        switch(choice)
        {
            case "1":
                AddMovie();
                break;
            case "2":
                ShowMovies();
                break;
            case "3":
                LoginMenu();
                break;
        }
    }

    static void AddMovie(){
        Console.WriteLine("Quel est le nom du nouveau film?");
        string? movieName = Console.ReadLine();
        Console.WriteLine("Quel est le prix du billet pour ce film?");
        string? inputPrice = Console.ReadLine();
        int.TryParse(inputPrice, out int price);
        Console.WriteLine("Quel est la description du filme");
        string? movieDescription = Console.ReadLine();
        Console.WriteLine("Quel est la categorie du film?");
        string? movieCategory = Console.ReadLine();
        Console.WriteLine("Quand le filme va sortir? Exemple: 12/10/2025 15:30");
        string? inputTime = Console.ReadLine();
        DateTime ScheduleFilm;
        DateTime.TryParse(inputTime, out ScheduleFilm);

        Movie newMovie = new Movie(movieName,price,movieDescription,movieCategory,ScheduleFilm);
        movies.Add(newMovie);
        AdminMenu();
    }

    static void ShowMovies(){
        foreach (var movie in movies)
        {
            Console.WriteLine($"Nom du film: {movie.Name}");
            Console.WriteLine($"Description: {movie.Description}");
            Console.WriteLine($"Catégorie: {movie.Category}");
            Console.WriteLine($"Prix: {movie.Price}€");
            Console.WriteLine($"Heure du film: {movie.ShowTime}");
            Console.WriteLine();
        }
        AdminMenu();
    }

    static void GuessMenu(){
        Console.WriteLine("1. Afficher tout les films");
        Console.WriteLine("2. Afficher les filmes de une catégorie");
        Console.WriteLine("3. Quitter");
        string choice = Console.ReadLine();
        switch(choice){
            case"1":
                ShowMoviesGuess();
                break;
            case"2":
                SortByCategory();
                break;
            case"3":
                LoginMenu();
                break;
        }
    }
    static void ShowMoviesGuess(){
        foreach (var movie in movies)
        {
            Console.WriteLine($"Nom du film: {movie.Name}");
            Console.WriteLine($"Description: {movie.Description}");
            Console.WriteLine($"Catégorie: {movie.Category}");
            Console.WriteLine($"Prix: {movie.Price}€");
            Console.WriteLine($"Heure du film: {movie.ShowTime}");
            Console.WriteLine();
        }
        GuessMenu();
    }
    static void SortByCategory(){
        Console.WriteLine("Quel catégorie voulez vous regarde?");
        string wantedCategory = Console.ReadLine();
        var filteredCategory = movies.Where(m => m.Category.Equals(wantedCategory, StringComparison.OrdinalIgnoreCase)).ToList();

        if(filteredCategory.Any()){
            foreach (var movie in filteredCategory){
                Console.WriteLine($"Nom du film: {movie.Name}");
                Console.WriteLine($"Description: {movie.Description}");
                Console.WriteLine($"Catégorie: {movie.Category}");
                Console.WriteLine($"Prix: {movie.Price}€");
                Console.WriteLine($"Heure du film: {movie.ShowTime}");
                Console.WriteLine();
                GuessMenu();
            }
        }else{
            Console.WriteLine("Aucune catégorie trouvé!");
            GuessMenu();
        }
    }
}

class Movie{
    public string? Name { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public DateTime ShowTime { get; set; }

    public Movie(string name, int price, string description, string category, DateTime showtime){
        Name = name;
        Price = price;
        Description = description;
        Category = category;
        ShowTime = showtime;
    }
}
