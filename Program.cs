using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp91
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddingPlayer = "1";
            const string CommandBanPlayer = "2";
            const string CommandUnbanPlayer = "3";
            const string CommandDeletePlayer = "4";
            const string CommandExitProgramm = "5";

            bool isOpen = true;
            string userInput = "";

            Player[] players = { new Player("Олаф", 5, 50), new Player("Викинг", 10, 75), new Player("Воин", 9, 45) };
            Database database = new Database();

            while (isOpen)
            {
                Console.WriteLine(" Добро пожаловать в список базы данных игроков. ");

                for (int i = 0; i < players.Length; i++)
                {
                    Console.Write(i + " ");
                    players[i].ShowStats();
                    
                }

                Console.WriteLine(CommandAddingPlayer + " - Добавить игрока ");
                Console.WriteLine(CommandBanPlayer + " - Забанить игрока по уникальному номеру ");
                Console.WriteLine(CommandUnbanPlayer + " - Разбанить игрока по уникальному номеру ");
                Console.WriteLine(CommandDeletePlayer + " - Удалить игрока по уникальному номеру ");
                Console.WriteLine(CommandExitProgramm + " - Выход из программы ");

                switch (userInput)
                {
                    case CommandAddingPlayer:
                        database.AddPlayer();
                        break;                   
                    
                    case CommandBanPlayer:
                        database.BanPlayer(); 
                        break;
                         
                }
            }

        }
    }

    class Player
    {
        private string _name;
        private int _id;
        private int _level;
        private bool _isBanned;

        public Player(string name, int id, int level)
        {
            _name = name;
            _id = id;
            _level = level;
            _isBanned = false;
        }

        public void ShowStats()
        {         
            Console.WriteLine($" айди - {_id}, имя игрока - {_name}, уровень игрока - {_level} ");
        }

        public void Ban()
        {
            _isBanned = true;
        }

        public void Unban()
        {
            _isBanned = false;
        }
    }

    class Database 
    {      
        private List<Player> _players = new List<Player>();
       
        public void AddPlayer ()
        { 
            Console.Write(" Пропишите имя игроку ");
            string name = Console.ReadLine();

            int level = GetNumber(" Введите уровень ");
            int id = GetNumber(" Введите айди игрока ");

            _players.Add(new Player(name, id, level));            
        }

        private int GetNumber(string text)
        {
            Console.WriteLine(text);
            int.TryParse(Console.ReadLine(), out int number);
            return number;

        }

        public void BanPlayer()
        {
            int id = GetNumber(" Пропишите айди игрока ");
            bool playerIsbanned = false;

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i]._id == id)
                {
                    _players[i].Ban();
                    playerIsbanned = true;
                }
            }

            if (playerIsbanned)
            {
                Console.WriteLine(" Пользователь забанен ");
            }
            else 
            {
                Console.WriteLine(" пользователь не найден ");
            }
        }
    }

}
