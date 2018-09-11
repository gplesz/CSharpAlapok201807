using System;
using System.Collections.Generic;
using System.Text;

namespace _03CodeFirstCore.Models
{
    public class Teacher
    {
        //[Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Subject> Subject { get; set; }

    }
}
