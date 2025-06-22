using babis.Models;

namespace babis.Data
{
    public static class DbSeeder
    {
        public static void SeedCategories(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "geography", Description = "Questions about geography" },
                    new Category { Name = "actors/movies", Description = "Questions about actors and movies" },
                    new Category { Name = "music", Description = "Questions about music" },
                    new Category { Name = "math/physic", Description = "Questions about math and physics" },
                    new Category { Name = "fauna/flora", Description = "Questions about animals and plants" }
                );
                context.SaveChanges();
            }
        }

        public static void SeedQuestions(AppDbContext context)
        {
            // Pobierz kategorie po nazwie
            var geography = context.Categories.FirstOrDefault(c => c.Name == "geography");
            var actorsMovies = context.Categories.FirstOrDefault(c => c.Name == "actors/movies");
            var music = context.Categories.FirstOrDefault(c => c.Name == "music");
            var mathPhysic = context.Categories.FirstOrDefault(c => c.Name == "math/physic");
            var faunaFlora = context.Categories.FirstOrDefault(c => c.Name == "fauna/flora");

            if (!context.Questions.Any() && geography != null && actorsMovies != null && music != null && mathPhysic != null && faunaFlora != null)
            {
                var questions = new List<Question>
                {
                    // --- GEOGRAPHY ---
                    new Question { QuestionContent = "What is the capital of France?", Options = new() { "Paris", "London", "Berlin", "Madrid" }, CorrectAnswer = 0, Category = geography },
                    new Question { QuestionContent = "Which continent is the Sahara Desert located on?", Options = new() { "Asia", "Africa", "Australia", "Europe" }, CorrectAnswer = 1, Category = geography },
                    new Question { QuestionContent = "Which is the largest ocean?", Options = new() { "Atlantic", "Indian", "Pacific", "Arctic" }, CorrectAnswer = 2, Category = geography },
                    new Question { QuestionContent = "Mount Everest is located in which mountain range?", Options = new() { "Andes", "Alps", "Himalayas", "Rockies" }, CorrectAnswer = 2, Category = geography },
                    new Question { QuestionContent = "Which country has the most islands?", Options = new() { "Canada", "Sweden", "Indonesia", "Philippines" }, CorrectAnswer = 1, Category = geography },
                    new Question { QuestionContent = "What is the longest river in the world?", Options = new() { "Amazon", "Nile", "Yangtze", "Mississippi" }, CorrectAnswer = 1, Category = geography },
                    new Question { QuestionContent = "Which desert is the largest?", Options = new() { "Gobi", "Kalahari", "Sahara", "Antarctic" }, CorrectAnswer = 3, Category = geography },
                    new Question { QuestionContent = "Which city is known as the Big Apple?", Options = new() { "Los Angeles", "New York", "Chicago", "Miami" }, CorrectAnswer = 1, Category = geography },
                    new Question { QuestionContent = "Which country is shaped like a boot?", Options = new() { "Spain", "Italy", "Greece", "Portugal" }, CorrectAnswer = 1, Category = geography },
                    new Question { QuestionContent = "What is the smallest country in the world?", Options = new() { "Monaco", "Vatican City", "San Marino", "Liechtenstein" }, CorrectAnswer = 1, Category = geography },

                    // --- ACTORS/MOVIES ---
                    new Question { QuestionContent = "Which actor played Iron Man?", Options = new() { "Chris Evans", "Robert Downey Jr.", "Chris Hemsworth", "Mark Ruffalo" }, CorrectAnswer = 1, Category = actorsMovies },
                    new Question { QuestionContent = "Who directed the movie 'Inception'?", Options = new() { "Steven Spielberg", "Christopher Nolan", "James Cameron", "Quentin Tarantino" }, CorrectAnswer = 1, Category = actorsMovies },
                    new Question { QuestionContent = "Which movie won Best Picture at the 2020 Oscars?", Options = new() { "1917", "Joker", "Parasite", "Ford v Ferrari" }, CorrectAnswer = 2, Category = actorsMovies },
                    new Question { QuestionContent = "Who played Jack in 'Titanic'?", Options = new() { "Brad Pitt", "Leonardo DiCaprio", "Tom Cruise", "Matt Damon" }, CorrectAnswer = 1, Category = actorsMovies },
                    new Question { QuestionContent = "Which actress played Hermione in Harry Potter?", Options = new() { "Emma Stone", "Emma Watson", "Jennifer Lawrence", "Natalie Portman" }, CorrectAnswer = 1, Category = actorsMovies },
                    new Question { QuestionContent = "Which movie features the quote 'I'll be back'?", Options = new() { "Predator", "Terminator", "Commando", "Total Recall" }, CorrectAnswer = 1, Category = actorsMovies },
                    new Question { QuestionContent = "Who played the Joker in 'The Dark Knight'?", Options = new() { "Joaquin Phoenix", "Heath Ledger", "Jared Leto", "Jack Nicholson" }, CorrectAnswer = 1, Category = actorsMovies },
                    new Question { QuestionContent = "Which movie is about a theme park with dinosaurs?", Options = new() { "Jurassic Park", "King Kong", "Godzilla", "Avatar" }, CorrectAnswer = 0, Category = actorsMovies },
                    new Question { QuestionContent = "Who directed 'Pulp Fiction'?", Options = new() { "Martin Scorsese", "Quentin Tarantino", "Francis Ford Coppola", "Stanley Kubrick" }, CorrectAnswer = 1, Category = actorsMovies },
                    new Question { QuestionContent = "Which actor starred in 'Mission: Impossible'?", Options = new() { "Tom Cruise", "Matt Damon", "Ben Affleck", "George Clooney" }, CorrectAnswer = 0, Category = actorsMovies },

                    // --- MUSIC ---
                    new Question { QuestionContent = "Who is known as the King of Pop?", Options = new() { "Elvis Presley", "Freddie Mercury", "Michael Jackson", "Prince" }, CorrectAnswer = 2, Category = music },
                    new Question { QuestionContent = "Which band released the album 'Abbey Road'?", Options = new() { "The Beatles", "The Rolling Stones", "Pink Floyd", "Queen" }, CorrectAnswer = 0, Category = music },
                    new Question { QuestionContent = "Who sang 'Shape of You'?", Options = new() { "Ed Sheeran", "Justin Bieber", "Shawn Mendes", "Sam Smith" }, CorrectAnswer = 0, Category = music },
                    new Question { QuestionContent = "Which singer is known for the song 'Hello'?", Options = new() { "Adele", "Beyoncé", "Rihanna", "Taylor Swift" }, CorrectAnswer = 0, Category = music },
                    new Question { QuestionContent = "Which band is famous for 'Bohemian Rhapsody'?", Options = new() { "Queen", "The Beatles", "Pink Floyd", "Led Zeppelin" }, CorrectAnswer = 0, Category = music },
                    new Question { QuestionContent = "Who is the lead singer of U2?", Options = new() { "Bono", "Sting", "Mick Jagger", "Freddie Mercury" }, CorrectAnswer = 0, Category = music },
                    new Question { QuestionContent = "Which artist released 'Bad Guy'?", Options = new() { "Billie Eilish", "Lorde", "Dua Lipa", "Ariana Grande" }, CorrectAnswer = 0, Category = music },
                    new Question { QuestionContent = "Who composed the Four Seasons?", Options = new() { "Mozart", "Vivaldi", "Bach", "Beethoven" }, CorrectAnswer = 1, Category = music },
                    new Question { QuestionContent = "Which rapper is known as 'Slim Shady'?", Options = new() { "Dr. Dre", "Eminem", "Snoop Dogg", "Kanye West" }, CorrectAnswer = 1, Category = music },
                    new Question { QuestionContent = "Which band released 'Stairway to Heaven'?", Options = new() { "Led Zeppelin", "Queen", "The Who", "Pink Floyd" }, CorrectAnswer = 0, Category = music },

                    // --- MATH/PHYSIC ---
                    new Question { QuestionContent = "What is the value of Pi (rounded to 2 decimal places)?", Options = new() { "3.12", "3.14", "3.16", "3.18" }, CorrectAnswer = 1, Category = mathPhysic },
                    new Question { QuestionContent = "What is the chemical symbol for water?", Options = new() { "O2", "H2O", "CO2", "NaCl" }, CorrectAnswer = 1, Category = mathPhysic },
                    new Question { QuestionContent = "What is 7 x 8?", Options = new() { "54", "56", "58", "60" }, CorrectAnswer = 1, Category = mathPhysic },
                    new Question { QuestionContent = "What is the speed of light (km/s)?", Options = new() { "300,000", "150,000", "299,792", "250,000" }, CorrectAnswer = 2, Category = mathPhysic },
                    new Question { QuestionContent = "Who developed the theory of relativity?", Options = new() { "Isaac Newton", "Albert Einstein", "Galileo Galilei", "Nikola Tesla" }, CorrectAnswer = 1, Category = mathPhysic },
                    new Question { QuestionContent = "What is the square root of 81?", Options = new() { "7", "8", "9", "10" }, CorrectAnswer = 2, Category = mathPhysic },
                    new Question { QuestionContent = "What is the formula for area of a circle?", Options = new() { "πr^2", "2πr", "πd", "r^2" }, CorrectAnswer = 0, Category = mathPhysic },
                    new Question { QuestionContent = "What is the freezing point of water (°C)?", Options = new() { "0", "32", "100", "-10" }, CorrectAnswer = 0, Category = mathPhysic },
                    new Question { QuestionContent = "What is 12 squared?", Options = new() { "124", "144", "164", "122" }, CorrectAnswer = 1, Category = mathPhysic },
                    new Question { QuestionContent = "What is the acceleration due to gravity (m/s²)?", Options = new() { "8.9", "9.8", "10.8", "11.8" }, CorrectAnswer = 1, Category = mathPhysic },

                    // --- FAUNA/FLORA ---
                    new Question { QuestionContent = "Which animal is known as the king of the jungle?", Options = new() { "Tiger", "Lion", "Elephant", "Leopard" }, CorrectAnswer = 1, Category = faunaFlora },
                    new Question { QuestionContent = "Which plant is known for its ability to survive in deserts?", Options = new() { "Rose", "Cactus", "Tulip", "Oak" }, CorrectAnswer = 1, Category = faunaFlora },
                    new Question { QuestionContent = "What is the largest mammal?", Options = new() { "Elephant", "Blue Whale", "Giraffe", "Hippopotamus" }, CorrectAnswer = 1, Category = faunaFlora },
                    new Question { QuestionContent = "Which bird is known for its colorful tail?", Options = new() { "Peacock", "Sparrow", "Eagle", "Penguin" }, CorrectAnswer = 0, Category = faunaFlora },
                    new Question { QuestionContent = "Which tree produces acorns?", Options = new() { "Pine", "Oak", "Maple", "Birch" }, CorrectAnswer = 1, Category = faunaFlora },
                    new Question { QuestionContent = "What is the fastest land animal?", Options = new() { "Cheetah", "Lion", "Horse", "Leopard" }, CorrectAnswer = 0, Category = faunaFlora },
                    new Question { QuestionContent = "Which animal is a marsupial?", Options = new() { "Kangaroo", "Elephant", "Dog", "Cat" }, CorrectAnswer = 0, Category = faunaFlora },
                    new Question { QuestionContent = "Which flower is a symbol of love?", Options = new() { "Tulip", "Rose", "Lily", "Daisy" }, CorrectAnswer = 1, Category = faunaFlora },
                    new Question { QuestionContent = "Which animal is known for building dams?", Options = new() { "Otter", "Beaver", "Mole", "Rabbit" }, CorrectAnswer = 1, Category = faunaFlora },
                    new Question { QuestionContent = "What is the tallest animal?", Options = new() { "Elephant", "Giraffe", "Horse", "Camel" }, CorrectAnswer = 1, Category = faunaFlora }
                };

                context.Questions.AddRange(questions);
                context.SaveChanges();
            }
        }

        public static void SeedUsers(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Name = "Anna Nowak", Gender = Gender.Female },
                    new User { Name = "Jan Kowalski", Gender = Gender.Male },
                    new User { Name = "Patryk Zieliński", Gender = Gender.Male },
                    new User { Name = "Katarzyna Wiśniewska", Gender = Gender.Female },
                    new User { Name = "Alex Smith", Gender = Gender.Other }
                );
                context.SaveChanges();
            }
        }
    }
}
