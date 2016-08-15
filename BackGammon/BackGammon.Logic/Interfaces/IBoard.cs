using BackGammon.Logic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Interfaces
{
    public interface IBoard
    {
        void initaliseBoard();
        int GetStoneCount(int CellNumber);
        GameStone GetStone(int CellNumber);
        int GetOutSideBarCount(StoneColor Color);
        bool CanMoveGameStone(int FromCell, int CountOfStoneMove);
        bool CanPutGameStoneBackInBoard(StoneColor Color, int CellNumber);
        bool HasAllGameStonesHome(StoneColor Color, int Except);
        void MoveGameStone(int FromCell, int CountOfStoneMove);
        void PutGameStoneBackOnBoard(StoneColor Color, int CellNumber);
        int GetPlayersGameStonesInHome(StoneColor Color);
        int GetBlackBar();
        int GetWhiteBar();
        bool WhitePlayerHasMoveToMake(int DiceOne, int DiceTwo);
        bool BlackPlayerHasMoveToMake(int DiceOne, int DiceTwo);
    }
}
