using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    [Owned]
    public class Email
    {
        public string Adress { get; set; }

        public Email()
        {

        }

        public Email(String email)
        {
            //this.email = email;
            //this.email = Create(email).ToString();
        }

        static public Email Create(string email)
        {
            /*if (ValidateEmail(email))
            {
                return new Email(email);
            }
            throw new ArgumentException("email");*/
            return new Email(email);
        }

        /*static public Boolean ValidateEmail(string email)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"

               + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"

               + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"

               + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"

               + @"[a-zA-Z]{2,}))$";

            Regex regexStrict = new Regex(patternStrict);
            return regexStrict.IsMatch(email);
        }

        public int CompareTo(Email other)
        {
            return String.Compare(this.email, other.email, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool Equals(Email other)
        {
            return CompareTo(other) == 0;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return email;
        }*/
    }
}
