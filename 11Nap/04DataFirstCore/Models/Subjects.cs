using System;
using System.Collections.Generic;

namespace _04DataFirstCore.Models
{
    public partial class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }

        public Teachers Teacher { get; set; }
    }
}
