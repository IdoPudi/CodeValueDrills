using BackGammon.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Classes
{
    public class ShowDices : IShowDices
    {
        Dices _dice;

        #region Constructor
        public ShowDices(Dices dice)
        {
            _dice = dice;
        }
        #endregion

        #region Public Methods
        public int GetDiceOne() => _dice.GetDiceOne();

        public int GetDiceOneMoves() => _dice.DiceOneNumberOfMoves();

        public int GetDiceTotalMoves() => _dice.TotalNumberOfMoves();

        public int GetDiceTwo() => _dice.GetDiceTwo();

        public int GetDiceTwoMoves() => _dice.DiceTwoNumberOfMoves();

        public bool IsDicesRolled() => _dice.IsDicesRolled();

        public bool IsOnDice(int Number) => _dice.IsOnDice(Number); 
        #endregion
    }
}
