using System;
using System.Linq;
using System.Text.RegularExpressions;

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

        public Student(string email, string name = null)
        {
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Email is invalid. It should be \"***.***@***.***\"", nameof(email));
            }

            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            this.Name = name ?? GetNameFromEmail(email);
            this.Email = email;
        }
        
        private static string GetNameFromEmail(string email)
        {
            var splitEmail = email.Substring(0, email.IndexOf('@'))
                                  .Split('.');
            var firstName = splitEmail[0];
            var secondName = splitEmail[1];

            return firstName.First().ToString().ToUpper() + firstName.Substring(1) + ' ' +
                   secondName.First().ToString().ToUpper() + secondName.Substring(1);
        }

        private static bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^([a-z]+)\.([a-z]+)@([a-z]+)\.([a-z]+)$");
            return regex.IsMatch(email.ToLower());
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