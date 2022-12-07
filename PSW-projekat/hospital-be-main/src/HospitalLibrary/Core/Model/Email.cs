using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    [Owned]
    public class Email
    {
        public string Adress { get; private set; }

        public Email() {}

        static public Email Create(string email)
        {
            if (ValidateEmail(email))
            {
                Email email2 = new Email();
                email2.Adress = email;
                return email2;
            }
            throw new ArgumentException("email");
        }

        static public Boolean ValidateEmail(string email)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"

               + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"

               + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"

               + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"

               + @"[a-zA-Z]{2,}))$";

            Regex regexStrict = new Regex(patternStrict);
            return regexStrict.IsMatch(email);
        }
    }
}
