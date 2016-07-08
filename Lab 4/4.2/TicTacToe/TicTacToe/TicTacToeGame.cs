using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int isGameOver = 0;

        public void StartGame()
        {
            do
            {
                Console.Clear(); 
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)  
                    Console.WriteLine("Player 2 Chance");
                else
                    Console.WriteLine("Player 1 Chance");
                Console.WriteLine("\n");
                ShowBoard();  
                choice = int.Parse(Console.ReadLine());
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) 
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else   
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                isGameOver = CheckWin(); 
            } while (isGameOver != 1 && isGameOver != -1); 
            Console.Clear(); 
            ShowBoard();
            if (isGameOver == 1)
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            else
                Console.WriteLine("Draw");
            Console.ReadLine();
        }

        private void ShowBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin()
        {
            if (arr[1] == arr[2] && arr[2] == arr[3])
                return 1;
            else if (arr[4] == arr[5] && arr[5] == arr[6])
                return 1;
            else if (arr[6] == arr[7] && arr[7] == arr[8])
                return 1;
            else if (arr[1] == arr[4] && arr[4] == arr[7])
                return 1;
            else if (arr[2] == arr[5] && arr[5] == arr[8])
                return 1;
            else if (arr[3] == arr[6] && arr[6] == arr[9])
                return 1;
            else if (arr[1] == arr[5] && arr[5] == arr[9])
                return 1;
            else if (arr[3] == arr[5] && arr[5] == arr[7])
                return 1;
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
                return -1;
            else
                return 0;
        }
    }
}
