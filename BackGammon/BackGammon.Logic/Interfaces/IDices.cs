using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Interfaces
{
    public interface IDices
    {
        void RollDices();
        bool IsOnDice(int Number);
        void RollDifferentDices();
        void UseDice(int Number);
        bool IsDicesRolled();
        int GetDiceOne();
        int GetDiceTwo();
        int DiceOneNumberOfMoves();
        int DiceTwoNumberOfMoves();
        int TotalNumberOfMoves();
    }
}
