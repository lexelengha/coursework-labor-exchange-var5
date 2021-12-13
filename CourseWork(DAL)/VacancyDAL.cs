using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_DAL_
{
    [Serializable]
    public class VacancyDAL
    {
        private CustomerDAL customer { get; set; }
        private string categoryOfWork { get; set; }
        private int experience { get; set; }
        private int desirableSalary { get; set; }
        private bool isDistance { get; set; }
        private bool isCarrerGrowth { get; set; }
        private string additionalInfo { get; set; }

        public VacancyDAL(CustomerDAL customer, string categoryOfWork, int experience, int desirableSalary, bool isDistance, bool isCarrerGrowth, string additionalInfo)
        {
            this.customer = customer;
            this.categoryOfWork = categoryOfWork;
            this.experience = experience;
            this.desirableSalary = desirableSalary;
            this.isDistance = isDistance;
            this.isCarrerGrowth = isCarrerGrowth;
            this.additionalInfo = additionalInfo;
        }

        public string AdditionalInfo
        {
            get
            {
                return additionalInfo;
            }
            set
            {
                additionalInfo = value;
            }
        }

        public bool IsCarrerGrowth
        {
            get
            {
                return isCarrerGrowth;
            }
            set
            {
                isCarrerGrowth = value;
            }
        }

        public bool IsDistance
        {
            get
            {
                return isDistance;
            }
            set
            {
                isDistance = value;
            }
        }

        public int DesirableSalary
        {
            get
            {
                return desirableSalary;
            }
            set
            {
                desirableSalary = value;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
            }
        }

        public string CategoryOfWork
        {
            get
            {
                return categoryOfWork;
            }
            set
            {
                categoryOfWork = value;
            }
        }

        public CustomerDAL Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
            }
        }
    }
}
