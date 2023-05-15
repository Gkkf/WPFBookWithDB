using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace KsiazkaWPF
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

        public Person() 
        {
            
        }

        public Person(string name, string surname, string number, string email)
        {
            Name = name;
            Surname = surname;
            Number = number;
            Email = email;
        }
    }
}
