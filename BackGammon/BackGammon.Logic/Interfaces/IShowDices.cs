using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Interfaces
{
    public interface IShowDices
    {
        bool IsOnDice(int Number);
        bool IsDicesRolled();
        int GetDiceOne();
        int GetDiceTwo();
        int GetDiceOneMoves();
        int GetDiceTwoMoves();
        int GetDiceTotalMoves();
    }
}
