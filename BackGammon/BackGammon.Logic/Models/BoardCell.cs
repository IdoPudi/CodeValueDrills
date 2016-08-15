using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackGammon.Logic.Classes.GameStone;

namespace BackGammon.Logic.Classes
{
    public class BoardCell
    {
        public int Number { get; set; }
        public StoneColor Color { get; set; }
    }
}
