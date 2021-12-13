using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CourseWork_DAL_
{
    public class MainInDAL
    {
        List<UnemployedDAL> unemployedDALs = new List<UnemployedDAL>();
        List<CustomerDAL> customerDALs = new List<CustomerDAL>();
        List<ResumeDAL> resumeDALs = new List<ResumeDAL>();
        List<VacancyDAL> vacancyDALs = new List<VacancyDAL>();

        public MainInDAL() { }

        public MainInDAL(List<VacancyDAL> vacancyDALs)
        {
            try
            {
                this.vacancyDALs = vacancyDALs;
            }
            catch
            {
                throw new ExceptionsWhenInitializeClass("Something wrong while initialize classes");
            }
            WriteOnFileVacancy();
        }
        public void WriteOnFileVacancy()
        {
            try
            {
                File.Delete("ListOfVacancy.dat");
            }
            catch
            {
                throw new ExceptionFileDoesntExist("File ListOfVacancy doesnt exist.");
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfVacancy.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, vacancyDALs.ToArray());
                }
                catch
                {
                    throw new ExceptionWhileSerialize("Something wrong when serialize vacancy");
                }
            }
        }
        public List<VacancyDAL> ReadFromFileVacancy()
        {
            vacancyDALs.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("ListOfVacancy.dat"))
            {
                using (FileStream fs = new FileStream($"ListOfVacancy.dat", FileMode.OpenOrCreate))
                {
                    VacancyDAL[] vacancyDALdes;
                    try
                    {
                        vacancyDALdes = (VacancyDAL[])formatter.Deserialize(fs);
                    }
                    catch
                    {
                        throw new ExceptionWhileDeseralize("Something wrong when deseralize vacancy");
                    }
                    for (int i = 0; i < vacancyDALdes.Length; i++)
                    {
                        vacancyDALs.Add(vacancyDALdes[i]);
                    }
                }
            }
            return vacancyDALs;
        }

        public MainInDAL(List<ResumeDAL> resumeDALs)
        {
            try
            {
                this.resumeDALs = resumeDALs;
            }
            catch
            {
                throw new ExceptionsWhenInitializeClass("Something wrong while initialize classes");
            }
            WriteOnFileResume();
        }
        public void WriteOnFileResume()
        {
            try
            {
                File.Delete("ListOfResume.dat");
            }
            catch
            {
                throw new ExceptionFileDoesntExist("File ListOfResume doesnt exist.");
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfResume.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, resumeDALs.ToArray());
                }
                catch
                {
                    throw new ExceptionWhileSerialize("Something wrong when serialize resume");
                }
            }
        }
        public List<ResumeDAL> ReadFromFileResume()
        {
            resumeDALs.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("ListOfResume.dat"))
            {
                using (FileStream fs = new FileStream($"ListOfResume.dat", FileMode.OpenOrCreate))
                {
                    ResumeDAL[] resumeDALdes;
                    try
                    {
                        resumeDALdes = (ResumeDAL[])formatter.Deserialize(fs);
                    }
                    catch
                    {
                        throw new ExceptionWhileDeseralize("Something wrong when deseralize resume");
                    }
                    for (int i = 0; i < resumeDALdes.Length; i++)
                    {
                        resumeDALs.Add(resumeDALdes[i]);
                    }
                }
            }
            return resumeDALs;
        }

        public MainInDAL(List<UnemployedDAL> unemployedDALs)
        {
            try
            {
                this.unemployedDALs = unemployedDALs;
            }
            catch
            {
                throw new ExceptionsWhenInitializeClass("Something wrong while initialize classes");
            }
            WriteOnFileUnemployed();
        }
        public void WriteOnFileUnemployed()
        {
            try
            {
                File.Delete("ListOfUnemployed.dat");
            }
            catch
            {
                throw new ExceptionFileDoesntExist("File ListOfUnemployed doesnt exist.");
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfUnemployed.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, unemployedDALs.ToArray());
                }
                catch
                {
                    throw new ExceptionWhileSerialize("Something wrong when serialize unemployed");
                }
            }
        }
        public List<UnemployedDAL> ReadFromFileUnemployed()
        {
            unemployedDALs.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("ListOfUnemployed.dat"))
            {
                using (FileStream fs = new FileStream($"ListOfUnemployed.dat", FileMode.OpenOrCreate))
                {
                    UnemployedDAL[] unemDALdes;
                    try
                    {
                        unemDALdes = (UnemployedDAL[])formatter.Deserialize(fs);
                    }
                    catch
                    {
                        throw new ExceptionWhileDeseralize("Something wrong when deseralize unemployed");
                    }
                    for (int i = 0; i < unemDALdes.Length; i++)
                    {
                        unemployedDALs.Add(unemDALdes[i]);
                    }
                }
            }
            return unemployedDALs;
        }


        public MainInDAL(List<CustomerDAL> customerDALs)
        {
            try
            {
                this.customerDALs = customerDALs;
            }
            catch
            {
                throw new ExceptionsWhenInitializeClass("Something wrong while initialize classes");
            }
            WriteOnFileCustomer();
        }
        public void WriteOnFileCustomer()
        {
            try
            {
                File.Delete("ListOfCustomer.dat");
            }
            catch
            {
                throw new ExceptionFileDoesntExist("File ListOfCustomer doesnt exist.");
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfCustomer.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, customerDALs.ToArray());
                }
                catch
                {
                    throw new ExceptionWhileSerialize("Something wrong when serialize customer");
                }
            }
        }
        public List<CustomerDAL> ReadFromFileCustomer()
        {
            customerDALs.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("ListOfCustomer.dat"))
            {
                using (FileStream fs = new FileStream($"ListOfCustomer.dat", FileMode.OpenOrCreate))
                {
                    CustomerDAL[] custDALdes;
                    try
                    {
                        custDALdes = (CustomerDAL[])formatter.Deserialize(fs);
                    }
                    catch
                    {
                        throw new ExceptionWhileDeseralize("Something wrong when deseralize customer");
                    }
                    for (int i = 0; i < custDALdes.Length; i++)
                    {
                        customerDALs.Add(custDALdes[i]);
                    }
                }
            }
            return customerDALs;
        }
    }
}
