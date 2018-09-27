using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Games
    {
        string nextLevel = "Foyer";
        bool IsKeyfound = false;
        bool IsChestopen = false;
        bool IsLevelComplete = false;
        bool IsFourkeyfound = false;
        bool IsCorrect = false;
        bool IsQuestionR = false;
        bool IsFinal = false;
        bool IsMonsterdead = false;
        bool IsDoorgood = false;
        bool IsMazegood = false;
        Random rand = new Random();
        Random monrand = new Random();
        int Lifepoints = 100;
        int monsterhp = 150;

        public void Gametime()
        {
            while (nextLevel != "GameOver")
            {
                if (nextLevel == "Foyer")
                {
                    Foyer();
                }
                else if (nextLevel == "Doors")
                {
                    Doors();
                }
                else if (nextLevel == "Maze")
                {
                    Maze();
                }
                else if (nextLevel == "Trapdoor")
                {
                    Trapdoor();
                }
                else if (nextLevel == "Rocks")
                {
                    Rocks();
                }
                else if (nextLevel == "Battle Arena")
                {
                    BattleArena();

                }
                else if (nextLevel == "Securedcode")
                {
                    Securedcode();
                }
                else if (nextLevel == "Winner")
                {
                    Winner();
                }
                else
                {
                    GamesTools.WriteColoredParagraph("ERROR: Where are you going?! You scared?", ConsoleColor.White, ConsoleColor.Red);
                    nextLevel = "GameOver";
                }
            }
        }

        public void Foyer()
        {
            Console.WriteLine();
            GamesTools.WriteColoredParagraph("FOYER: MAIN ROOM", ConsoleColor.Red, ConsoleColor.White);
            Console.WriteLine();
            GamesTools.WriteParagraph(@"You are in the Main room the house. Suddenly... The door shuts behind you! You are trapped in the house!
You must find the keys to get out of this place! The house has weird black wallpaper marked 'DO NOT BE STUPID OR ELSE.' Adventure awaits for you!");
            Console.WriteLine();
            GamesTools.WriteColoredParagraph("To continue on your journey go, (N)orth.", ConsoleColor.Black, ConsoleColor.Yellow);

            string choice = GamesTools.GetChoice("n");

            if (choice == "n")
            {
                nextLevel = "Doors";
            }

            else
            {
                Console.WriteLine("That's not right man!");

            }



        }


        public void Doors()
        {

            Console.WriteLine();
            GamesTools.WriteColoredParagraph("LEVEL: DOORS", ConsoleColor.Yellow, ConsoleColor.Red);
            Console.WriteLine();
            GamesTools.WriteParagraph(@"
You currently in the level called 'DOORS'. It seems there a three doors to choose from. The room has three flaming skulls above the doors. 
If you choose the wrong door, you will be returned to the beginning. Hahaha
                ");



            string choice;

            if (IsDoorgood == false)
            {
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can go (L)eft, (M)iddle, (R)ight, (B)ack.", ConsoleColor.Yellow, ConsoleColor.Black);
                choice = GamesTools.GetChoice("l", "m", "r", "b");
            }

            else
            {
                Console.WriteLine();
                GamesTools.WriteParagraph("You see the middle door is already opened!");
                GamesTools.WriteColoredParagraph("You see that the middle door is open! (GO)OOOO!", ConsoleColor.Yellow, ConsoleColor.Black);
                choice = GamesTools.GetChoice("go");
            }


            if (choice == "m")
            {
                IsDoorgood = true;
                GamesTools.WriteColoredParagraph(@" Excellent! Good start on your journey! Don't die or else I'll tell your mom.", ConsoleColor.Yellow, ConsoleColor.DarkMagenta);
                nextLevel = "Maze";
            }
            else if (choice == "b")
            {
                nextLevel = "Foyer";
            }
            else if (choice == "l" || choice == "r")
            {
                nextLevel = "Doors";
                GamesTools.WriteColoredParagraph(@" Hey, you were here like a second ago. Welcome back!", ConsoleColor.White, ConsoleColor.Black);
                Console.WriteLine();
                int hpLost = rand.Next(2, 5);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph($@"OH NO! THAT WAS THE WRONG DOOOR! YOU LOST {hpLost} HIT POINTS!
                ", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.Red);
            }
            else if (choice == "go")
            {
                nextLevel = "Maze";
            }

            if (Lifepoints > 0 && IsDoorgood == true)
            {
                nextLevel = "Maze";

            }
            else if (Lifepoints <= 0)
            {
                GamesTools.WriteColoredParagraph("OH NOOOOOO!", ConsoleColor.Red, ConsoleColor.White);
                GamesTools.WriteColoredParagraph("NOOOO! YOU DIED SO YOUNG!", ConsoleColor.Red, ConsoleColor.White);
                nextLevel = "GameOver";
            }
        }







        public void Maze()
        {

            Console.WriteLine();
            GamesTools.WriteColoredParagraph("LEVEL: MAZE", ConsoleColor.Blue, ConsoleColor.Yellow);
            Console.WriteLine();
            GamesTools.WriteParagraph
                (@"You are in a Maze which has multiple ways to go. Be careful of which way you go! Or else you'll end up at the beginning of the maze!");
            Console.WriteLine();

            Console.WriteLine();
            GamesTools.WriteColoredParagraph("You can go (E)ast, (N)orth, (S)outh, (W)est", ConsoleColor.Yellow, ConsoleColor.Black);

            string choice;


            if (IsMazegood == false)
            {
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("Which way to go?! MMMMMWENSWNSWWSSEENNWMMMMMMM?", ConsoleColor.Yellow, ConsoleColor.Black);

                choice = GamesTools.GetChoice("e", "n", "s", "w");
            }

            else
            {
                Console.WriteLine();
                GamesTools.WriteParagraph("The West path is already lit with torches on the wall guiding you!");
                GamesTools.WriteColoredParagraph("The (W)est path is bright and shining", ConsoleColor.Yellow, ConsoleColor.Black);
                choice = GamesTools.GetChoice("w");
            }

            if (choice == "w")
            {
                GamesTools.WriteColoredParagraph(@"YOU SEE A KEY AS YOU WALK DOWN THE DARK PATH...AS YOU REACHED THE END...THE PATH LIGHTS UP!", ConsoleColor.Yellow, ConsoleColor.DarkMagenta);
                GamesTools.WriteColoredParagraph(@" Excellent! Now make me proud by going forward! Seems to be no key in this room. Dinkleberg!!!", ConsoleColor.White, ConsoleColor.Black);
                nextLevel = "Trapdoor";

                IsMazegood = true;

            }
            else if (choice == "s")
            {
                Console.WriteLine("You forget something? mmmm I see. ");
                nextLevel = "Doors";

            }

            else if (choice == "e" || choice == "n")
            {
                nextLevel = "Foyer";

                Console.WriteLine();
                int hpLost = rand.Next(5, 10);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OH NO! THAT WAS THE WRONG WAY! YOU WERE MAGICALLY TELEPORTED BACK TO THE FOYER!!! AHHH! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);
            }


            if (Lifepoints > 0 && IsMazegood == true)
            {
                nextLevel = "Trapdoor";
            }
            else if (Lifepoints <= 0)
            {
                GamesTools.WriteColoredParagraph("", ConsoleColor.Red, ConsoleColor.White);
                GamesTools.WriteColoredParagraph("NOOOO! YOU DIED SO YOUNG!", ConsoleColor.Red, ConsoleColor.White);
                nextLevel = "GameOver";
            }
        }




        public void Trapdoor()
        {

            Console.WriteLine();
            GamesTools.WriteColoredParagraph("LEVEL: TRAPDOOR!", ConsoleColor.Yellow, ConsoleColor.Red);
            Console.WriteLine();
            GamesTools.WriteParagraph(@"
This room has a trapdoor lying around waiting for you to fall in! Be careful or else escape isn't possible!
There are three doors on other side of the room. There is also a chest next to you... MMM!
                ");
            Console.WriteLine();

            string choice;
            if (IsChestopen == false)
            {
                GamesTools.WriteParagraph(@"
You see there a chest next to you and you wonder what is inside of this chest. Could it be a key? <0____0>
                    ");
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can go (N)orth, (E)ast, or you can (K)ick the chest open.", ConsoleColor.Red, ConsoleColor.Black);
                choice = GamesTools.GetChoice("e", "n", "k");
                GamesTools.WriteParagraph("There seems to be a key inside. Should I grab it?");
            }

            else if (IsKeyfound == false)
            {
                GamesTools.WriteParagraph(@"
Wow looks what's in this chest. Should I grab it or leave? mmmmm
                    ");
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can go (N)orth, (E)ast, or you can (G)rab the key.", ConsoleColor.Red, ConsoleColor.Black);
                choice = GamesTools.GetChoice("e", "n", "g");
                GamesTools.WriteParagraph("You got the key in your hands! What are you going to do next?!");
            }


            else
            {

                Console.WriteLine();
                GamesTools.WriteColoredParagraph("Look at this! Already been here before!", ConsoleColor.Yellow, ConsoleColor.Red);
                GamesTools.WriteColoredParagraph("(G)o to the Rocky area! LOVELY!", ConsoleColor.Yellow, ConsoleColor.DarkMagenta);
                choice = GamesTools.GetChoice("g");

            }

            if (choice == "e")
            {
                nextLevel = "Maze";

                Console.WriteLine();
                int hpLost = rand.Next(7, 11);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OH NO! YOU WERE MAGICALLY TELEPORTED BACK TO THE MAZE! THE PUZZLE RESETTED! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.Yellow, ConsoleColor.DarkMagenta);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.Red);
            }
            else if (choice == "g")
            {
                IsKeyfound = true;
                nextLevel = "Rocks";
            }

            else if (choice == "k")
            {
                IsChestopen = true;
                nextLevel = "Trapdoor";
            }



            else if (choice == "n")
            {
                Console.WriteLine();
                int hpLost = rand.Next(2, 5);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"COM'N MAN! WHAT ARE YOU DOING?! {hpLost} HIT POINTS!", ConsoleColor.Yellow, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.Red);
                GamesTools.WriteColoredParagraph("Did you forget something? I know you did...", ConsoleColor.Black, ConsoleColor.Yellow);
                nextLevel = "Trapdoor";

            }

            if (Lifepoints > 0 && IsKeyfound == true)
            {
                nextLevel = "Rocks";

            }
            else if (Lifepoints <= 0)
            {
                GamesTools.WriteColoredParagraph("OH NOOOOOO!", ConsoleColor.Red, ConsoleColor.White);
                GamesTools.WriteColoredParagraph("NOOOO! YOU DIED SO YOUNG!", ConsoleColor.Red, ConsoleColor.White);
                nextLevel = "GameOver";
            }
        }












        public void Rocks()
        {
            Console.WriteLine();
            GamesTools.WriteColoredParagraph("LEVEL: ROCKY!", ConsoleColor.Yellow, ConsoleColor.Red);
            Console.WriteLine();
            GamesTools.WriteParagraph(@"
This room has small rocks slowly falling from the ceiling and seems there is no door in sight. Uh oh! Is this the end of the adventure or is the adventure just starting?
Let's rock and roll... See what I did there. hahaha. Once again you see a chest next to you. What will you do next?
                ");
            Console.WriteLine();

            string choice;

            if (IsLevelComplete == false)
            {
                GamesTools.WriteParagraph(@"
You see there is a boulder in your path. What will you do? Be smart about it! 
                    ");
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can (C)limb, you can(H)ug, you can (F)alcon Punch the boulder or (B)ack", ConsoleColor.Yellow, ConsoleColor.DarkMagenta);
                choice = GamesTools.GetChoice("h", "f", "c", "b");
            }



            else
            {

                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can go (B)ack, (W)est, (C)ome down to party town.", ConsoleColor.Black, ConsoleColor.Yellow);
                choice = GamesTools.GetChoice("w", "b", "c");
            }

            if (choice == "h")
            {
                nextLevel = "Rocks";

                Console.WriteLine();
                int hpLost = rand.Next(8, 15);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"YOU HUGGED THE LOVELY ROCK BUT THEN A BIG ROCK FALLS ON YOUR HEAD! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);
            }
            else if (choice == "f")
            {
                nextLevel = "Trapdoor";

                Console.WriteLine();
                int hpLost = rand.Next(9, 16);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"YOU FALCON PUNCHED THE BOULDER. NOT TOO SMART! YOU WERE TELEPORTED BACK A ROOM! BUT YOU ARE ENTERTAINING AT LEAST. YOU LOST {hpLost} HIT POINTS!"
                , ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);
            }

            else if (choice == "b")
            {
                nextLevel = "Trapdoor";

            }
            else if (choice == "w")
            {
                nextLevel = "Trapdoor";

                Console.WriteLine();
                int hpLost = rand.Next(5, 9);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"NO SIR! YOU WILL BE DENIED! NOW GET BACK! {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);
            }
            else if (choice == "c")
            {
                GamesTools.WriteColoredParagraph("As you climb over, ROCKS ARE FALLING AT A RAPID PACE BUT YOU SEE A KEY...YOU GRABBED IT SOMEHOW...AMAZING!", ConsoleColor.White, ConsoleColor.Red);

                GamesTools.WriteParagraph
(" Good choice to climb the rocks! A huge rock smashed through the floor causing all the entire room to collapse. You are now Underground somewhere...");
                nextLevel = "Battle Arena";
            }

            if (IsLevelComplete == true && Lifepoints > 0)
            {
                IsLevelComplete = true;
                nextLevel = "Battle Arena";

            }
            else if (Lifepoints <= 0)
            {
                GamesTools.WriteColoredParagraph("OH NOOOOOO!", ConsoleColor.Red, ConsoleColor.White);
                GamesTools.WriteColoredParagraph("NOOOO! YOU DIED SO YOUNG!", ConsoleColor.Red, ConsoleColor.White);
                nextLevel = "GameOver";
            }
        }






        public void BattleArena()
        {

            Console.WriteLine();
            GamesTools.WriteColoredParagraph("BOSS: THE FIENDISH MENACE!", ConsoleColor.Yellow, ConsoleColor.Red);
            Console.WriteLine();
            GamesTools.WriteParagraph(@"You take a hard fall to the ground but you are fine. You get up to see where to go next.You see a staircase from a distance.
Suddenly.... A monster appears from the hole you fell from. This winged beast has a flaming head with horns, sharp claws, and sharp tail. Seems you have to fight this monster 
to get to the elevator and escape. You notice a shield and sword next to you.Sounds like a great idea to use these two to battle this fiend. Good luck! 
YOU CANNOT RUN AWAY FROM THIS BATTLE! TIME TO FIGHT!");
            Console.WriteLine();

            string choice;

            if (IsMonsterdead == false)
            {
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can (A)ttack with sword, (D)odge, (B)lock its attack", ConsoleColor.Black, ConsoleColor.DarkRed);
                choice = GamesTools.GetChoice("a", "d", "b");
            }
            else
            {
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("GO TO (Ch)amber of Secrets!", ConsoleColor.Black, ConsoleColor.Yellow);
                choice = GamesTools.GetChoice("ch");

            }



            if (choice == "a")
            {
                GamesTools.WriteColoredParagraph("You swing your sword at the creature.", ConsoleColor.White, ConsoleColor.Green);
                GamesTools.WriteParagraph
("You notice the fiend is in significant and you see your opinion. Suddenly... The demon strikes quickly by grabbing you and throwing you to the wall.");

                Console.WriteLine();
                int hpLost = rand.Next(5, 10);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU GOT SLAPPED IN THE FACE BY A TAIL! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Red);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);

                Console.WriteLine();
                int Monsterhplost = monrand.Next(20, 40);
                monsterhp = monsterhp - Monsterhplost;
                GamesTools.WriteColoredParagraph
                   ($@"YOU STRIKE THE CREATURE! The MONSTER LOST {Monsterhplost} HIT POINTS!", ConsoleColor.Black, ConsoleColor.White);
                GamesTools.WriteColoredParagraph($"The monster has {monsterhp} HP left", ConsoleColor.Black, ConsoleColor.DarkYellow);


                nextLevel = "Battle Arena";

            }

            else if (choice == "d")
            {
                GamesTools.WriteColoredParagraph("You dodge the creature's assault onto you then you striked its back before it could react.", ConsoleColor.Blue, ConsoleColor.Green);
                GamesTools.WriteParagraph("The creature's tail slaps you in the face after you caused damage to its back.");

                Console.WriteLine();
                int hpLost = rand.Next(5, 10);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU GOT SLAPPED IN THE FACE BY A TAIL! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);

                Console.WriteLine();
                int Monsterhplost = monrand.Next(20, 42);
                monsterhp = monsterhp - Monsterhplost;
                GamesTools.WriteColoredParagraph
                  ($@"YOU SLICE THE MONSTER'S FACE! The MONSTER LOST {Monsterhplost} HIT POINTS!", ConsoleColor.Black, ConsoleColor.White);
                GamesTools.WriteColoredParagraph($"The monster has {monsterhp} HP left", ConsoleColor.Black, ConsoleColor.DarkYellow);

                nextLevel = "Battle Arena";
            }

            else if (choice == "b")
            {
                GamesTools.WriteColoredParagraph
                    ("You block the creature's attack with your shield, then you counterattacked by slicing its face.", ConsoleColor.Blue, ConsoleColor.Green);
                GamesTools.WriteParagraph("You taken some damage but you hurt the fiend by striking its face.");

                Console.WriteLine();
                int hpLost = rand.Next(5, 10);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU GOT SLAPPED IN THE FACE BY A TAIL! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);

                Console.WriteLine();
                int Monsterhplost = monrand.Next(30, 50);
                monsterhp = monsterhp - Monsterhplost;

                GamesTools.WriteColoredParagraph
                 ($@"YOU COUNTER ATTACKED AND STABBED ITS BODY! The MONSTER LOST {Monsterhplost} HIT POINTS!", ConsoleColor.Black, ConsoleColor.White);
                GamesTools.WriteColoredParagraph($"The monster has {monsterhp} HP left", ConsoleColor.Black, ConsoleColor.DarkYellow);



                nextLevel = "Battle Arena";
            }

            if (monsterhp <= 0 && Lifepoints > 0)
            {
                GamesTools.WriteColoredParagraph(@"Excellent job! You have defeated the fiend that trapped you in this hellhole! You go upstairs to the next area! As you are
going up the stairs....YOU GRABBED A KEY!!!", ConsoleColor.White, ConsoleColor.DarkMagenta);
                IsMonsterdead = true;
                nextLevel = "Securedcode";
            }
            else if (Lifepoints <= 0)
            {
                GamesTools.WriteColoredParagraph("NOT YET....IT IS OVER!", ConsoleColor.Red, ConsoleColor.White);
                GamesTools.WriteColoredParagraph("NOOOO! YOU DIED SO YOUNG!", ConsoleColor.Red, ConsoleColor.White);
                nextLevel = "GameOver";
            }
        }















        public void Securedcode()
        {

            Console.WriteLine();
            GamesTools.WriteColoredParagraph("LEVEL: SECURITY CODE!", ConsoleColor.Yellow, ConsoleColor.Red);
            Console.WriteLine();
            GamesTools.WriteParagraph(@"
After a long battle. You climb the stairs to the next area. Once you reached the top of the stairs. You see that the area has a long path way.
                ");
            Console.WriteLine();

            string choice;

            if (IsFourkeyfound == false)
            {
                GamesTools.WriteParagraph(@"
You see the path takes you a large door with four key slots but there is a large bridge with several holes in them. I wonder how we can get across?
As you approach the first hole in the bridge you see that a question is on the wall... 'How many keys do you need in order to escape?'
                    ");
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can (Z)ero, (O)ne, (F)our ", ConsoleColor.DarkMagenta, ConsoleColor.Gray);
                choice = GamesTools.GetChoice("f", "o", "z");

            }

            else if (IsCorrect == false)
            {
                GamesTools.WriteParagraph(@"
What was the first level of this lovely palace? :D
                    ");
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can go (D)oors, (M)aze, or (R)ocks", ConsoleColor.Black, ConsoleColor.DarkYellow);
                choice = GamesTools.GetChoice("d", "m", "r");
                GamesTools.WriteParagraph("There you go! YOU ARE SOOOOOOOOO GOOD!");
            }

            else if (IsQuestionR == false)
            {
                GamesTools.WriteParagraph(@"
Which direction did you take in the second level of this lovely dungeon? ;)
                    ");
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can go (N)orth, (E)ast, or (W)est.", ConsoleColor.Black, ConsoleColor.Red);
                choice = GamesTools.GetChoice("e", "n", "w");
                GamesTools.WriteParagraph("You know how this works don't you?? ");
            }

            else if (IsFinal == false)
            {
                GamesTools.WriteParagraph(@"
Who is the best football team in college currently?
                    ");
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("You can go (G)eorgia, (Oh)io State, (A)labama or (V)anderbilt", ConsoleColor.Yellow, ConsoleColor.Red);
                choice = GamesTools.GetChoice("g", "oh", "a", "v");
                GamesTools.WriteParagraph("You know how this works don't you?? ");
            }
            else
            {

                Console.WriteLine();
                GamesTools.WriteParagraph("You been down this road, go ahead and win yourself a.....Ring?");
                GamesTools.WriteColoredParagraph("Go to (Ch)ampionship Game ", ConsoleColor.Black, ConsoleColor.Yellow);
                choice = GamesTools.GetChoice("ch");

                GamesTools.WriteParagraph(@"
You are about to be a winner!");
                nextLevel = "Winner";
            }










            if (choice == "f")
            {
                GamesTools.WriteColoredParagraph("You chose correctly!.", ConsoleColor.Red, ConsoleColor.DarkYellow);
                GamesTools.WriteParagraph
("The missing piece to the bridge appears and places perfectly into the long pathway towards the end.");

                IsFourkeyfound = true;

                nextLevel = "Securedcode";

            }

            else if (choice == "o")
            {
                GamesTools.WriteColoredParagraph("That's wrong!!! ", ConsoleColor.Red, ConsoleColor.DarkYellow);
                GamesTools.WriteParagraph("You are shot from a distance by an arrow!");

                Console.WriteLine();
                int hpLost = rand.Next(1, 3);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU GOT SHOT BY AN ARROW FROM A DISTANCE! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($"You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);

                nextLevel = "Securedcode";
            }

            else if (choice == "z")
            {
                GamesTools.WriteColoredParagraph
                    ("No sir! You know how many you got ;).", ConsoleColor.White, ConsoleColor.DarkCyan);
                GamesTools.WriteParagraph("Really?.");

                Console.WriteLine();
                int hpLost = rand.Next(1, 3);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU FELL THROUGH A TRAPDOOR! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);

                nextLevel = "Battle Arena";
            }

            if (choice == "d")
            {
                GamesTools.WriteColoredParagraph
                    ("YOU GOT IT! OH MY GOODNESS!.", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteParagraph("NEXT ONE!");

                nextLevel = "Securedcode";
                IsCorrect = true;
            }

            else if (choice == "m")
            {
                GamesTools.WriteColoredParagraph
                    ("Whoa! You know that is wrong!", ConsoleColor.DarkYellow, ConsoleColor.Black);
                GamesTools.WriteParagraph("Cannot let you pass! :p");

                Console.WriteLine();
                int hpLost = rand.Next(1, 3);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU HAVE BEEN REJECTED! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);


                nextLevel = "Battle Arena";
            }
            else if (choice == "r")
            {
                GamesTools.WriteColoredParagraph
                    ("No sir! NOT TODAY!.", ConsoleColor.Blue, ConsoleColor.Black);
                GamesTools.WriteParagraph("Really?.");

                Console.WriteLine();
                int hpLost = rand.Next(1, 3);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU HAVE BEEN REJECTED! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);


                nextLevel = "Battle Arena";
            }
            else if (choice == "n")
            {
                GamesTools.WriteColoredParagraph
                    ("Why must you do this to yourself?", ConsoleColor.Blue, ConsoleColor.Black);
                GamesTools.WriteParagraph("NO! NO! NO! NOOOOOO! ARGHHHHH!.");

                Console.WriteLine();
                int hpLost = rand.Next(1, 3);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU HAVE BEEN REJECTED! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);


                nextLevel = "Securedcode";
            }
            else if (choice == "e")
            {
                GamesTools.WriteColoredParagraph
                    ("Hahahahahahahahahahahaha NOPE!.", ConsoleColor.Blue, ConsoleColor.Black);
                GamesTools.WriteParagraph("NAH!.");

                Console.WriteLine();
                int hpLost = rand.Next(1, 3);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU HAVE BEEN REJECTED! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);



                nextLevel = "Battle Arena";
            }

            if (choice == "w")
            {
                GamesTools.WriteColoredParagraph
                    ("YOU GOT THAT CORRECT! GOOD JOB! ALMOST THERE!", ConsoleColor.Blue, ConsoleColor.Black);
                GamesTools.WriteParagraph("FREEDOM IS SO CLOSE!.");


                nextLevel = "Securedcode";
                IsQuestionR = true;
            }

            else if (choice == "g")
            {
                GamesTools.WriteColoredParagraph
                    ("Wishful thinking? Well....stop wishing", ConsoleColor.Blue, ConsoleColor.Black);
                GamesTools.WriteParagraph("You know this is wrong!");

                Console.WriteLine();
                int hpLost = rand.Next(3, 10);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU HAVE BEEN REJECTED! YOU FELL THROUGH A TRAPDOOR! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);


                nextLevel = "Battle Arena";
            }

            else if (choice == "oh")
            {
                GamesTools.WriteColoredParagraph
                    ("#2 but not the #1", ConsoleColor.Blue, ConsoleColor.Black);
                GamesTools.WriteParagraph("No cigar for you... actually cigars are bad for you.");

                Console.WriteLine();
                int hpLost = rand.Next(1, 5);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU HAVE BEEN REJECTED! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);


                nextLevel = "Securedcode";
            }
            else if (choice == "v")
            {
                GamesTools.WriteColoredParagraph
                    ("Homecoming game?", ConsoleColor.Blue, ConsoleColor.Black);
                GamesTools.WriteParagraph("4 & 1");

                Console.WriteLine();
                int hpLost = rand.Next(3, 10);
                Lifepoints = Lifepoints - hpLost;

                GamesTools.WriteColoredParagraph
                ($@"OUCH! YOU HAVE BEEN REJECTED! YOU FELL THROUGH A TRAPDOOR! YOU LOST {hpLost} HIT POINTS!", ConsoleColor.White, ConsoleColor.Black);
                GamesTools.WriteColoredParagraph($" You have {Lifepoints} HP left", ConsoleColor.White, ConsoleColor.DarkRed);


                nextLevel = "Battle Arena";
            }
            if (choice == "a")
            {
                GamesTools.WriteColoredParagraph
                    ("ROLL TIDE! YOU HAVE THE FOURTH KEY!", ConsoleColor.Blue, ConsoleColor.Black);
                GamesTools.WriteParagraph("You know this already!");

                IsFinal = true;

                nextLevel = "Winner";
            }

            if (Lifepoints > 0 && IsFinal == true)
            {
                nextLevel = "Winner";

            }
            else if (Lifepoints <= 0)
            {
                GamesTools.WriteColoredParagraph("OH NOOOOOO!", ConsoleColor.Red, ConsoleColor.White);
                GamesTools.WriteColoredParagraph("NOOOO! YOU DIED SO YOUNG!", ConsoleColor.Red, ConsoleColor.White);
                nextLevel = "GameOver";
            }


        }










        public void Winner()
        {
            Console.WriteLine();
            GamesTools.WriteColoredParagraph("LEVEL: GAME CHANGER", ConsoleColor.Yellow, ConsoleColor.Red);
            Console.WriteLine();
            GamesTools.WriteParagraph(@"
You use the FOUR KEYS you found in this mansion to open the large door which takes you to an unknown area...Seems like you are in the Foyer?...
After a long battle with this game. You have reached the end of the house. What will you do?
                ");
            Console.WriteLine();

            Console.WriteLine();
            GamesTools.WriteColoredParagraph("Go (S)outh to end this adventure OR (R)oll to the left for more unnecessary fun!.", ConsoleColor.DarkMagenta, ConsoleColor.Black);

            string choice = GamesTools.GetChoice("s", "r");

            if (choice == "s")
            {
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("Good job! You have successfully made it through this madhouse without dying. Hope to see you again!", ConsoleColor.Yellow, ConsoleColor.DarkMagenta);

                nextLevel = "GameOver";
            }

            else if (choice == "r")
            {
                Console.WriteLine();
                GamesTools.WriteColoredParagraph("Good job! You have successfully TELEPORTED YOURSELF BACK TO THE ARENA WHERE THE DEMON WAS!!!  IT IS DEAD ALREADY!! WOO!!!"
                    , ConsoleColor.Yellow, ConsoleColor.DarkMagenta);

                nextLevel = "Battle Arena";
            }

        }
    }
}

