using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_DAL_
{
    [Serializable]
    public class ResumeDAL
    {
        private UnemployedDAL unemployed { get; }
        private string categoryOfWork { get; }
        private int experience { get; }
        private int desirableSalary { get; }
        private string additionalInfo { get; }

        public ResumeDAL(UnemployedDAL unemployed, string categoryOfWork, int experience, int desirableSalary, string additionalInfo)
        {
            this.unemployed = unemployed;
            this.categoryOfWork = categoryOfWork;
            this.experience = experience;
            this.desirableSalary = desirableSalary;
            this.additionalInfo = additionalInfo;
        }

        public UnemployedDAL Unemployed
        {
            get
            {
                return unemployed;
            }
        }

        public string CategoryOfWork
        {
            get
            {
                return categoryOfWork;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }
        }

        public int DesirableSalary
        {
            get
            {
                return desirableSalary;
            }
        }

        public string AdditionalInfo
        {
            get
            {
                return additionalInfo;
            }
        }
    }
}
