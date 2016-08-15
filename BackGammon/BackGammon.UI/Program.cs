using BackGammon.Logic.Classes;
using BackGammon.UI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayBackGammon play = new PlayBackGammon();
            play.StartGame();
        }

        
    }
}
