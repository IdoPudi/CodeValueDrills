using BackGammon.Logic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.UI.Interfaces
{
    public interface IPrint
    {
        void DrawBoard(Board board);
        void PrintDicesAndNumberOfMoves(GameManager game);
        void GotStonesOnBar();
        void InputNotValid();
        void EnterNumber();
        void PressKryToRestartMove();
        void StartGame();
        void CurrentPlayer(StoneColor Color);
        void PlayerTurn(StoneColor Color);
        void ShowException(Exception ex);
        void NoMovesForPlayer();
        void NotAValidMove();
        void WinningPlayer(StoneColor Color);
    }
}
