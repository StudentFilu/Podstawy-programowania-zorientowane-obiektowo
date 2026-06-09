using System;
using System.Collections.Generic;
using System.Linq;

namespace Wisielec
{
    class Player
    {
        public string Name { get; private set;}
        public Player(string name)
        {
            Name = name;
        }
    }

    class WordBank
    {
        private List<string> words = new List<string>
        {
            "prokrastynacja",
            "elektrokardiogram",
            "wyindywidualizowany",
            "Hiszpania",
            "wulkanizacja"
        };
        private Random random = new Random();

        public string GetRandomWord()
        {
            int index = random.Next(words.Count);
            return words[index];
        }
    }

    class Game
    {
        private Player player;
        private string secretWord;
        private HashSet<char> guessedLetters;
        private int maxErrors;
        private int errors;

        public Game(Player player, WordBank wordBank, int maxErrors = 6)
        {
            this.player = player;
            this.secretWord = wordBank.GetRandomWord().ToLower();
            this.guessedLetters = new HashSet<char>();
            this.maxErrors = maxErrors;
            this.errors = 0;
        }

        public string GetDisplayWord()
        {
            var display = secretWord.Select(c => guessedLetters.Contains(c) ? c : '_');
            return string.Join(" ", display);
        }
        public void GuessLetter(char letter)
        {
            letter = char.ToLower(letter);
            if (guessedLetters.Contains(letter))
            {
                Console.WriteLine("Już zgadłeś tę literę!");
                return;
            }
            guessedLetters.Add(letter);
            if (secretWord.Contains(letter))
            {
                Console.WriteLine($"Ta litera jest w słowie.");
            }
            else
            {
                errors++;
                Console.WriteLine($"Niestety, ta litera nie jest w słowie. Błąd {errors}/{maxErrors}");
            }
        }

        public bool IsWon() => secretWord.All(c => guessedLetters.Contains(c));
        public bool IsLost() => errors >= maxErrors;
        public void StartLoop()
        {
            Console.WriteLine($"Witaj {player.Name}! Zacznijmy grę w wisielca!");
            while (!IsWon() && !IsLost())
            {                Console.WriteLine($"Słowo: {GetDisplayWord()}");
                Console.Write("Zgadnij literę: ");
                
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Wprowadzić pojedynczą literę.");
                    continue;
                }
                GuessLetter(input[0]);
            }
            if (IsWon())
            {
                Console.WriteLine($"Gratulacje {player.Name}, wygrałeś! Słowo to: {secretWord.ToUpper()}");
            }
            else
            {
                Console.WriteLine($"Niestety {player.Name}, przegrałeś. Słowo to: {secretWord.ToUpper()}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj swoje imię: ");
            string name = Console.ReadLine();
            Player player = new Player(name);
            WordBank wordBank = new WordBank();
            Game game = new Game(player, wordBank);
            game.StartLoop();
        }
    }
}