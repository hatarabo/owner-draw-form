using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HataRabo.Win32
{
    public class NativeMethod
    {
        /// <summary>
        /// 非クライアント領域の当たり判定
        /// </summary>
        public enum NcHitTest : int
        {
            Error = -2,
            Transparent = -1,
            NoWhere = 0,
            Client = 1,
            Caption = 2,
            SysMenu = 3,
            GrowBox = 4,
            Size = GrowBox,
            Menu = 5,
            HScroll = 6,
            VScroll = 7,
            MinButton = 8,
            MaxButton = 9,
            Left = 10,
            Right = 11,
            Top = 12,
            TopLeft = 13,
            TopRight = 14,
            Bottom = 15,
            BottomLeft = 16,
            BottomRight = 17,
            Border = 18,
            Reduce = MinButton,
            Zoom = MaxButton,
            SizeFirst = Left,
            SizeLast = BottomRight
        }

        /// <summary>
        /// 下位ビットの値を取得する
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static short LoWord(int input)
        {
            return (short)((int)input & 0xFFFF);
        }

        /// <summary>
        /// 上位ビットの値を取得する
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static short HiWord(int input)
        {
            return (short)((int)input >> 16);
        }
    }
}
