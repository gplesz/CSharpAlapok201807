using System;

namespace _09Delegate
{
    public class DataStoreWithDelegate
    {
        private int[] data;

        //függvény definíció, ami megmondja, hogy 
        //ez egy formai definíció, ami elmondja, hogy a függvényem, amit majd ProcessDef hivatkozással adok meg, hogy néz ki.
        public delegate int ProcessDef(int[] data);

        public DataStoreWithDelegate(int[] data)
        {
            this.data = data;
        }

        public int Process(ProcessDef strategy)
        {
            //todo: ellenőrzések
            return strategy(data);
        }

        public int Process2(Func<int[],int> strategy)
        {
            return strategy(data);
        }

        public int Process3(Func<int[], int> strategy)
        {
            return strategy(data);
        }
    }
}