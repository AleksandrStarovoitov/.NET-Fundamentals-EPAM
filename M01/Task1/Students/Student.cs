using System;
using System.Linq;

namespace Students
{
    internal class Student
    {
        private string email;

        public string Name { get; set; }

        public string Email
        {
            get => email;
            set
            {
                if (!GetNameFromEmail(value).Equals(this.Name))
                {
                    throw new ArgumentException("Email does not match the name", nameof(email));
                }

                this.email = value;
            }
        }

        public Student(string name, string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            this.Name = name ?? GetNameFromEmail(email);
            this.Email = email;
        }
        
        public Student(string email) : this(null, email) { }
        
        private static string GetNameFromEmail(string email)
        {
            var splitEmail = email.Substring(0, email.IndexOf('@'))
                                  .Split('.');
            var firstName = splitEmail[0];
            var secondName = splitEmail[1];

            return firstName.First().ToString().ToUpper() + firstName.Substring(1) + ' ' +
                   secondName.First().ToString().ToUpper() + secondName.Substring(1);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student student))
            {
                return false;
            }

            return ((student.Name == this.Name) && (student.Email == this.Email));
        }

        public override int GetHashCode()
        {
            unchecked 
            {
                var hash = 17;
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Email.GetHashCode();

                return hash;
            }
        }
    }
}