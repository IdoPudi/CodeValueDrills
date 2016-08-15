using BackGammon.Logic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Interfaces
{
    public interface IGameManager
    {
        bool CanMove(int FromCell, int CountOfStoneMove);
        void Move(int FromCell, int CountOfStoneMove);
        bool CanPut(int CellNumber);
        void Put(int CellNumber);
        Board GetBoard();
        StoneColor GetPlayer();
        bool IsEnded();
        StoneColor Winner();
        void Roll();
        ShowDices getDice();
        void RollStartingPlayer();
        int GetPlayerStoneOnBar(StoneColor Color);
        bool HasMove();
        
    }
}
