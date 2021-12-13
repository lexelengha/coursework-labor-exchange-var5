using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_DAL_
{
    [Serializable]
    public class CustomerDAL
    {
        private string firstname { get; }
        private string lastname { get; }
        private string phone { get; }

        public CustomerDAL(string firstname, string lastname, string phone)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.phone = phone;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
        }
    }
}
