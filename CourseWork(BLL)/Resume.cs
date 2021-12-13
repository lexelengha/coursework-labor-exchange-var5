using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_BLL_
{
    public class Resume
    {
        private Unemployed unemployed { get; set; }
        private string categoryOfWork { get; set; }
        private int experience { get; set; }
        private int desirableSalary { get; set; }
        private string additionalInfo { get; set; }

        public Resume(Unemployed unemployed, string categoryOfWork, int experience, int desirableSalary, string additionalInfo)
        {
            this.unemployed = unemployed;
            this.categoryOfWork = categoryOfWork;
            this.experience = experience;
            this.desirableSalary = desirableSalary;
            this.additionalInfo = additionalInfo;
        }

        public Unemployed Unemployed
        {
            get
            {
                return unemployed;
            }
            set
            {
                unemployed = value;
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
    }
}
