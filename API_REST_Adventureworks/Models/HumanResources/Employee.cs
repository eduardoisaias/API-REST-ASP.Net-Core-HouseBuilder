using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_Adventureworks.Models.HumanResources
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
    }
}
