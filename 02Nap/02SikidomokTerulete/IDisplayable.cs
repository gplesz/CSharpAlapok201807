using System;
using System.Collections.Generic;
using System.Text;

namespace _02SikidomokTerulete
{
    /// <summary>
    /// Ez a felület tartalmazza azokat a tulajdonságokat, aminek
    /// a segítségével megjeleníthető egy osztálypéldány
    /// </summary>
    interface IDisplayable
    {
        int PosX { get; set; }
        int PosY { get; set; }
    }
}
