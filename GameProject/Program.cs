using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            String response = "y";

            while (response == "y")
            {
                Games theGame = new Games();
                theGame.Gametime();

                Console.Write("Play Again (y/n)? ");
                response = Console.ReadLine();

            }
        }
    }
    }

