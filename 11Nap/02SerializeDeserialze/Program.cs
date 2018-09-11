using System;
using System.Collections.Generic;

namespace _02SerializeDeserialze
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new DataClass()
            {
                Text = "Ez itt egy árvíztűrő tükörfúrógép",
                Integer = int.MaxValue,
                DateTime = DateTime.MinValue,
                Double = Math.PI
            };

            var dataList = new DataList();
            dataList.DataClass = data;
            dataList.Data.Add(data);
            dataList.Data.Add(data);
            dataList.Data.Add(data);
            dataList.Data.Add(data);

            Console.WriteLine("Hello World!");
        }
    }


    public class DataClass
    {
        public int Integer { get; set; }
        public double Double { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
    }

    public class DataList
    {

        public DataList()
        {
            Data = new List<DataClass>();
        }

        public List<DataClass> Data { get; set; }

        public DataClass DataClass { get; set; }
    }
}
