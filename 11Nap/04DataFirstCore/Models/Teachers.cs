using System;
using System.Collections.Generic;

namespace _04DataFirstCore.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            Subjects = new HashSet<Subjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Subjects> Subjects { get; set; }
    }
}
