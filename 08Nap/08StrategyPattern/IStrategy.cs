using System;
using System.Collections.Generic;
using System.Text;

namespace _08StrategyPattern
{
    /// <summary>
    /// Valamennyi műveletvégzés "arca"
    /// minden (strategy) osztálynak implementálni kell a műveletvégző függvényt ebben a formában
    /// </summary>
    public interface IStrategy
    {
        int Process(int[] data);
    }
}
