using System;
using System.Collections.Generic;
using System.Text;

namespace EdwardsManagement
{
    public class Players
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Salary { get; set; }

        public override string ToString()
        {
                return $"{FirstName} {LastName} + '$' + {Salary}";
        }
    }
}
