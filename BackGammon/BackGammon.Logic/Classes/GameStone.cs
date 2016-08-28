using BackGammon.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon.Logic.Classes
{
    public class GameStone : IGameStone
    {
        public static GameStone White = new GameStone(StoneColor.White);
        public static GameStone Black = new GameStone(StoneColor.Black);
        public static GameStone None = new GameStone(StoneColor.None);

        #region Private Members
        private StoneColor _color;
        #endregion

        #region Constructor
        public GameStone(StoneColor color)
        {
            _color = color;
        }

        public GameStone(bool color)
        {
            _color = (color ? StoneColor.White : StoneColor.Black);
        }

        public GameStone()
        {
            _color = StoneColor.None;
        }
        #endregion

        #region Properties
        public StoneColor Color
        {
            get { return _color; }
            set { _color = value; }
        }
        #endregion


    }

    public enum StoneColor
    {
        [Description("O")]
        White,
        [Description("#")]
        Black,
        [Description(" ")]
        None
    }

    public static class ExtensionMethods
    {
        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(
                                              typeof(DescriptionAttribute),
                                              false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
    }
}
