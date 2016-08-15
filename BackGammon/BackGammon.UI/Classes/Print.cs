using BackGammon.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGammon.Logic.Classes;

namespace BackGammon.UI.Classes
{
    public class Print : IPrint
    {
        StringBuilder _sb;

        #region Constructor
        public Print()
        {
            _sb = new StringBuilder();
        }
        #endregion

        #region Public Methods
        public void DrawBoard(Board board)
        {
            _sb.Clear();
            _sb.Append($"*******************************************************\n");
            _sb.Append($"*** White player = O ************* Black player = # ***\n");
            _sb.Append($"*******************************************************\n");
            _sb.Append($"--0---1---2---3---4---5---BW----6---7---8---9--10--11--\n");

            for (int i = 1; i <= 7; i++)
            {
                DrawTopStoneLine(i, board, _sb);
                _sb.Append($"|\n");
            }

            _sb.Append($"=======================================================\n");
            for (int i = 7; i >= 1; i--)
            {
                DrawBottomStoneLine(i, board, _sb);
                _sb.Append($"\n");
            }

            _sb.Append($"--23--22--21--20--19--18--BB---17--16--15--14--13--12--\n");
            Console.WriteLine(_sb);
        }

        public void PrintDicesAndNumberOfMoves(GameManager game)
        {
            Console.WriteLine($"Dice number 1 :{game.getDice().GetDiceOne()}, number of moves left:{game.getDice().GetDiceOneMoves()}");
            Console.WriteLine($"Dice number 1 :{game.getDice().GetDiceTwo()}, number of moves left:{game.getDice().GetDiceTwoMoves()}");
            Console.WriteLine($"Total number of moves left :{game.getDice().GetDiceTotalMoves()}");
        }

        public void GotStonesOnBar()
        {
            Console.WriteLine($"You have stones on bar");
        }

        public void InputNotValid()
        {
            Console.WriteLine($"You can only input numbers");
        }

        public void EnterNumber()
        {
            Console.WriteLine($"Please enter a number");
        }

        public void PressKryToRestartMove()
        {
            Console.WriteLine($"Please press any key to restart move");
        }

        public void StartGame()
        {
            Console.WriteLine($"Welcome to BackGammon Console Game");
            Console.WriteLine($"To start playing please press on any key");
        }

        public void CurrentPlayer(StoneColor Color)
        {
            Console.WriteLine($"Current player :{Color}");
        }

        public void PlayerTurn(StoneColor Color)
        {
            Console.Clear();
            Console.WriteLine($"********************");
            Console.WriteLine($"Player {Color} turn");
            Console.WriteLine($"********************");
            Console.WriteLine($"Press any key to start turn");
            Console.ReadKey();
        }

        public void ShowException(Exception ex)
        {
            Console.WriteLine($"An error of type : {ex.Message} happened");
            Console.WriteLine($"Please press any key to start move again");
            Console.ReadKey();
        }

        public void NoMovesForPlayer()
        {
            Console.WriteLine($"Player dont have any moves to do");
            Console.WriteLine($"Please press any key to switch players");
            Console.ReadKey();
        }

        public void NotAValidMove()
        {
            Console.WriteLine($"Move not valid");
            Console.WriteLine($"Please press any key to start move again");
            Console.ReadKey();
        }

        public void WinningPlayer(StoneColor Color)
        {
            Console.WriteLine($"**********************");
            Console.WriteLine($"We have a winner!!!!!");
            Console.WriteLine($"**********************");
            Console.WriteLine($"Player {Color} Win");
            Console.WriteLine($"**********************");
            Console.ReadKey();
        }
        #endregion

        #region Private Merthods
        private static void DrawBottomStoneLine(int i, Board b, StringBuilder sb)
        {
            for (int j = 23; j > 17; j--)
            {
                DrawSegment(i, j, b, sb);
            }
            sb.Append($"|| ");
            if (b.GetOutSideBarCount(StoneColor.Black) >= i)
            {
                sb.Append(b.GetBlackBar());
            }
            else
            {
                sb.Append(' ');
            }
            sb.Append($" |");
            for (int j = 17; j > 11; j--)
            {
                DrawSegment(i, j, b, sb);
            }
        }

        private static void DrawTopStoneLine(int i, Board b, StringBuilder sb)
        {
            for (int j = 0; j < 6; j++)
            {
                DrawSegment(i, j, b, sb);
            }
            sb.Append($"|| ");
            if (b.GetOutSideBarCount(StoneColor.White) >= i)
            {
                sb.Append(b.GetWhiteBar());
            }
            else
            {
                sb.Append(' ');
            }

            sb.Append($" |");
            for (int j = 6; j < 12; j++)
            {
                DrawSegment(i, j, b, sb);
            }
        }

        private static void DrawSegment(int i, int j, Board b, StringBuilder sb)
        {
            sb.Append($"| ");
            if (b.GetStoneCount(j) >= i)
            {
                StoneColor color = b.GetStone(j).Color;
                sb.Append(color.ToDescription());
            }
            else
            {
                sb.Append(' ');
            }
            sb.Append($" ");
        } 
        #endregion
    }
}
