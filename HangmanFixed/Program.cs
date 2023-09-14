using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Intro screen + initial string array
            Console.WriteLine("Hello, Welcome To Hangman!");
            Console.WriteLine("When you feel like you know the word, just GO FOR IT! ");
            Console.WriteLine("Press ENTER to start, or add your own word: ");

            string[] words = {  "SHOWERHEAD", "SCHOOL", "IRIDOCYCLITIS", "JAZZ", "SMITE", "TACIT", "LADDER", "HOUSE", "BEAR", "CAT", "DOG", "TABLE", "AXIOM", "DINOSAUR", "CONCEPTUALIZE" };
            //List made of the array "words" and how to get a random word
            List<string> guessingWords = new List<string>(words);
            Random random = new Random();

            int rnd = random.Next(guessingWords[0].Length);
            string secretWord = guessingWords[rnd];
            string guessString = new string('_', secretWord.Length);

            //List for already guessed characters (continuation later on in the program)
            List<string> alrGuessed = new List<string>();

            //Add your own word + a bool that checks when you lose (used later on)
            string newWord = Console.ReadLine().ToUpper();
            guessingWords.Add(newWord);

            bool lose = false;
            
            //To change the guessString
            StringBuilder guessBuilder = new StringBuilder(guessString);

            //Declaring the variable j to draw out the hangman&
            int j = 4;

            //Start of loop
            while (lose==false)
            {
                Console.Clear();

                Console.WriteLine("Already guessed characters: "+ string.Join(", ", alrGuessed.ToArray()));
                Console.WriteLine("Lives left: " + j);
                //Drawing out the the hanging man
                if (j == 4)


                {
                    
                    Console.WriteLine("                ");
                    Console.WriteLine("---x---I");
                    Console.WriteLine("   |   I");
                    Console.WriteLine("       I");
                    Console.WriteLine("       I");
                    Console.WriteLine("       I");
                    Console.WriteLine("       I");
                    Console.WriteLine("-------I");



                }
                else if (j == 3)
                {


                    Console.WriteLine("             ");
                    Console.WriteLine("---x---I");
                    Console.WriteLine("   |   I");
                    Console.WriteLine("   O   I");
                    Console.WriteLine("       I");
                    Console.WriteLine("       I");
                    Console.WriteLine("       I");
                    Console.WriteLine("-------I");


                }


                else if (j == 2)
                {
                    Console.WriteLine("             ");
                    Console.WriteLine("---x---I");
                    Console.WriteLine("   |   I");
                    Console.WriteLine("   O   I");
                    Console.WriteLine("   |   I");
                    Console.WriteLine("       I");
                    Console.WriteLine("       I");
                    Console.WriteLine("-------I");


                }
                else if (j == 1)
                {
                    Console.WriteLine("         ");
                    Console.WriteLine("---x---I");
                    Console.WriteLine("   |   I");
                    Console.WriteLine("   O   I");
                    Console.WriteLine("  /|\\  I");
                    Console.WriteLine("       I");
                    Console.WriteLine("       I");
                    Console.WriteLine("-------I");


                }
                else if (j == 0)
                {
                    Console.WriteLine("             ");
                    Console.WriteLine("---x---I");
                    Console.WriteLine("   |   I");
                    Console.WriteLine("   O   I");
                    Console.WriteLine("  /|\\  I");
                    Console.WriteLine("  / \\  I");
                    Console.WriteLine("       I");
                    Console.WriteLine("-------I");

                    Console.WriteLine(guessString);
                    Console.WriteLine("Too bad, you lose!. The word was: " + secretWord);
                    lose = true;
                    break;
                }


                bool correctLetterGuess = false;
                bool correctWordGuess = false;
                
                
                Console.WriteLine("The word is "+ guessBuilder);
                Console.Write("Guess a letter: ");
                
                string wordGuess = Console.ReadLine().ToUpper();
                alrGuessed.Add(wordGuess);

                StringBuilder Sb1 = new StringBuilder();
               
                //The guessing block
                if (secretWord.Contains(wordGuess))
                {
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == wordGuess[0])
                        {
                            Sb1.Append(secretWord[i] + " ");
                            guessBuilder[i] = secretWord[i];
                            correctLetterGuess = true;

                        }

                    }
                }
                else
                {
                    Console.WriteLine("Incorrect letter");
                    j--;
                Thread.Sleep(1000);
                }
                
                //Checking if the user input is the same as the secretWord
                if (wordGuess == secretWord)
                {

                        Console.WriteLine("Congratulations, you guessed right! The word was " + secretWord);
                        Thread.Sleep(2000);
                        break;
                }
               
                //Checking if the guessBuilder (the changed guessString) has all of the letters of the secretWord --> win con.
                    if (secretWord.Equals(guessBuilder.ToString()))
                    {

                        Console.WriteLine("Congratulations, you guessed right! The word was " + secretWord);
                        Thread.Sleep(2000);
                   
                        break;
                    }





                
            } //End of loop
        }
    }
}

