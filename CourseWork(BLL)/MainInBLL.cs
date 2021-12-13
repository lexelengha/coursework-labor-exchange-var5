using System;
using CourseWork_DAL_;
using System.Collections.Generic;

namespace CourseWork_BLL_
{
    public class MainInBLL
    {
        List<Unemployed> unemployeds = new List<Unemployed>();
        List<Customer> customers = new List<Customer>();
        List<Resume> resumes = new List<Resume>();
        List<Vacancy> vacancies = new List<Vacancy>();

        public MainInBLL() { }

        //VACANCY
        public void addVacancy(int count, string categoryOfWork, int experience, int desirableSalary, bool isDistance, bool isCarrerGrowth, string additionalInfo)
        {
            Vacancy vacancy;
            try
            {
                vacancy = new Vacancy(customers[count], categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
            }
            catch
            {
                throw new ExceptionWhenInitializeClass("Something wrong with parameters while initialize class in function AddVacancy.");
            }       
            vacancies.Add(vacancy);
            writeOnFileVacancy();
        }
        public int getCountOfVacancy()
        {
            return vacancies.Count;
        }
        public string getShortInfoVacancy(int count)
        {
            return $"Customer: {vacancies[count].Customer.Firstname} {vacancies[count].Customer.Lastname}: Category: {vacancies[count].CategoryOfWork};";
        }
        public string getMoreInfoAboutVacancy(int count)
        {
            return $"Customer: {vacancies[count].Customer.Firstname} {vacancies[count].Customer.Lastname}: {vacancies[count].Customer.Phone}; \n" +
                $"Category of work: {vacancies[count].CategoryOfWork}; \n" +
                $"Minimal experience: {vacancies[count].Experience}; \n" +
                $"Desirable salary: {vacancies[count].DesirableSalary}; \n" +
                $"Distance work: {vacancies[count].IsDistance.ToString()}; \n" +
                $"Carrer growth: {vacancies[count].IsCarrerGrowth.ToString()}; \n" +
                $"Additional info: {vacancies[count].AdditionalInfo};";
        }
        public void editStringInfoVacancy(int whatToChange, int count, string info)
        {
            switch (whatToChange)
            {
                case 1:
                    vacancies[count].CategoryOfWork = info;
                    break;
                case 2:
                    vacancies[count].AdditionalInfo = info;
                    break;
            }
            writeOnFileVacancy();
        }
        public void editIntInfoVacancy(int whatToChange, int count, int info)
        {
            switch (whatToChange)
            {
                case 1:
                    vacancies[count].Experience = info;
                    break;
                case 2:
                    vacancies[count].DesirableSalary = info;
                    break;
            }
            writeOnFileVacancy();
        }
        public void editBoolInfoVacancy(int whatToChange, int count, bool info)
        {
            switch (whatToChange)
            {
                case 1:
                    vacancies[count].IsDistance = info;
                    break;
                case 2:
                    vacancies[count].IsCarrerGrowth = info;
                    break;
            }
            writeOnFileVacancy();
        }
        public void writeOnFileVacancy()
        {
            List<VacancyDAL> vacancyDALs = new List<VacancyDAL>();
            for (int i = 0; i < vacancies.Count; i++)
            {
                try
                {
                    CustomerDAL customerDAL = new CustomerDAL(vacancies[i].Customer.Firstname, vacancies[i].Customer.Lastname, vacancies[i].Customer.Phone);
                    VacancyDAL vacancyDAL = new VacancyDAL(customerDAL, vacancies[i].CategoryOfWork, vacancies[i].Experience, vacancies[i].DesirableSalary, vacancies[i].IsDistance, vacancies[i].IsCarrerGrowth, vacancies[i].AdditionalInfo);
                    vacancyDALs.Add(vacancyDAL);
                }
                catch
                {
                    throw new ExceptionWhenIndexOutOfRange("Index out of range in function writeOnFileVacancy.");
                }
            }
            MainInDAL mainInDAL = new MainInDAL(vacancyDALs);
        }
        public void getInfoFromFileVacancy()
        {
            vacancies.Clear();
            MainInDAL mainInDAL = new MainInDAL();
            List<VacancyDAL> vacancyDALs = mainInDAL.ReadFromFileVacancy();
            for (int i = 0; i < vacancyDALs.Count; i++)
            {
                try
                {
                    Customer customer = new Customer(vacancyDALs[i].Customer.Firstname, vacancyDALs[i].Customer.Lastname, vacancyDALs[i].Customer.Phone);
                    Vacancy vacancy = new Vacancy(customer, vacancyDALs[i].CategoryOfWork, vacancyDALs[i].Experience, vacancyDALs[i].DesirableSalary, vacancyDALs[i].IsDistance, vacancyDALs[i].IsCarrerGrowth, vacancyDALs[i].AdditionalInfo);
                    vacancies.Add(vacancy);
                }
                catch
                {
                    throw new ExceptionWhenIndexOutOfRange("Index out of range in function getInfoFromFileVacancy.");
                }
            }
        }
        public string getCategoryOfWorkVacancy(int count)
        {
            return vacancies[count].CategoryOfWork;
        }
        public void deleteVacancy(int count)
        {
            vacancies.RemoveAt(count);
        }


        //RESUME
        public void addResume(int count, string categoryOfWork, int experience, int desirableSalary, string additionalInfo)
        {
            Resume resume;
            try
            {
                resume = new Resume(unemployeds[count], categoryOfWork, experience, desirableSalary, additionalInfo);
            }
            catch
            {
                throw new ExceptionWhenInitializeClass("Something wrong with parameters while initialize class in function addResume.");
            }
            resumes.Add(resume);
            writeOnFileResume();
        }
        public int getCountOfResume()
        {
            return resumes.Count;
        }
        public string getShortInfoResume(int count)
        {
            return $"Unemployed: {resumes[count].Unemployed.Firstname} {resumes[count].Unemployed.Lastname}: Category: {resumes[count].CategoryOfWork};";
        }
        public string getMoreInfoAboutResume(int count)
        {
            return $"Unemployed: {resumes[count].Unemployed.Firstname} {resumes[count].Unemployed.Lastname}: {resumes[count].Unemployed.Phone}; \n" + 
                $"Category of work: {resumes[count].CategoryOfWork}; \n" +
                $"Experience: {resumes[count].Experience}; \n" +
                $"Desirable salary: {resumes[count].DesirableSalary}; \n" +
                $"Additional info: {resumes[count].AdditionalInfo};";
        }
        public void editStringInfoResume(int whatToChange, int count, string info)
        {
            switch (whatToChange)
            {
                case 1:
                    resumes[count].CategoryOfWork = info;
                    break;
                case 2:
                    resumes[count].AdditionalInfo = info;
                    break;
            }
            writeOnFileResume();
        }
        public void editIntInfoResume(int whatToChange, int count, int info)
        {
            switch (whatToChange)
            {
                case 1:
                    resumes[count].Experience = info;
                    break;
                case 2:
                    resumes[count].DesirableSalary = info;
                    break;
            }
            writeOnFileResume();
        }
        public void writeOnFileResume()
        {
            List<ResumeDAL> resumeDALs = new List<ResumeDAL>();
            for (int i = 0; i < resumes.Count; i++)
            {
                try
                {
                    UnemployedDAL unemployedDAL = new UnemployedDAL(resumes[i].Unemployed.Firstname, resumes[i].Unemployed.Lastname, resumes[i].Unemployed.Phone);
                    ResumeDAL resumeDAL = new ResumeDAL(unemployedDAL, resumes[i].CategoryOfWork, resumes[i].Experience, resumes[i].DesirableSalary, resumes[i].AdditionalInfo);
                    resumeDALs.Add(resumeDAL);
                }
                catch
                {
                    throw new ExceptionWhenIndexOutOfRange("Index out of range in function writeOnFileResume.");
                }
            }
            MainInDAL mainInDAL = new MainInDAL(resumeDALs);
        }
        public void getInfoFromFileResume()
        {
            resumes.Clear();
            MainInDAL mainInDAL = new MainInDAL();
            List<ResumeDAL> resumeDALs = mainInDAL.ReadFromFileResume();
            for (int i = 0; i < resumeDALs.Count; i++)
            {
                try
                {
                    Unemployed unemployed = new Unemployed(resumeDALs[i].Unemployed.Firstname, resumeDALs[i].Unemployed.Lastname, resumeDALs[i].Unemployed.Phone);
                    Resume resume = new Resume(unemployed, resumeDALs[i].CategoryOfWork, resumeDALs[i].Experience, resumeDALs[i].DesirableSalary, resumeDALs[i].AdditionalInfo);
                    resumes.Add(resume);
                }
                catch
                {
                    throw new ExceptionWhenIndexOutOfRange("Index out of range in function getInfoFromFileResume.");
                }
            }
        }
        public string getCategoryOfWorkResume(int count)
        {
            return resumes[count].CategoryOfWork;
        }
        public void deleteResume(int count)
        {
            resumes.RemoveAt(count);
        }

        //UNEMPLOYED
        public void addUnemployed(string firstname, string lastname, string phone)
        {
            Unemployed unemployed;
            try
            {
                unemployed = new Unemployed(firstname, lastname, phone);
            }
            catch
            {
                throw new ExceptionWhenInitializeClass("Something wrong with parameters while initialize class in function addUnemployed.");
            }
            unemployeds.Add(unemployed);
            writeOnFileUnemployed();
        }
        public string getPhoneOfUnemployed(int count)
        {
            return unemployeds[count].Phone;
        }
        public int getCountOfUnemployeds()
        {
            return unemployeds.Count;
        }
        public string getShortInfoOfUnemployeds(int count)
        {
            return $"{unemployeds[count].Firstname} {unemployeds[count].Lastname}";
        }
        public string getMoreInfoAboutUnemployed(int count)
        {
            string result = $"Firstname: {unemployeds[count].Firstname}; \n" +
                $"Lastname: {unemployeds[count].Lastname}; \n" +
                $"Phone: {unemployeds[count].Phone}; \n";
            return result;
        }
        public void editStringInfoUnemployed(int whatToChange, int count, string info)
        {
            switch (whatToChange)
            {
                case 1:
                    unemployeds[count].Firstname = info;
                    break;
                case 2:
                    unemployeds[count].Lastname = info;
                    break;
                case 3:
                    unemployeds[count].Phone = info;
                    break;
            }
            writeOnFileUnemployed();
        }
        public void writeOnFileUnemployed()
        {
            List<UnemployedDAL> unemployedDALs = new List<UnemployedDAL>();
            for (int i = 0; i < unemployeds.Count; i++)
            {
                try
                {
                    UnemployedDAL unemployedDAL = new UnemployedDAL(unemployeds[i].Firstname, unemployeds[i].Lastname, unemployeds[i].Phone);
                    unemployedDALs.Add(unemployedDAL);
                }
                catch
                {
                    throw new ExceptionWhenIndexOutOfRange("Index out of range in function writeOnFileUnemployed.");
                }
            }
            MainInDAL mainInDAL = new MainInDAL(unemployedDALs);
        }
        public void getInfoFromFileUnemployed()
        {
            unemployeds.Clear();
            MainInDAL mainInDAL = new MainInDAL();
            List<UnemployedDAL> unemployedDALs = mainInDAL.ReadFromFileUnemployed();
            for (int i = 0; i < unemployedDALs.Count; i++)
            {
                try
                {
                    Unemployed unemployed = new Unemployed(unemployedDALs[i].Firstname, unemployedDALs[i].Lastname, unemployedDALs[i].Phone);
                    unemployeds.Add(unemployed);
                }
                catch
                {
                    throw new ExceptionWhenIndexOutOfRange("Index out of range in function getInfoFromFileUnemployed.");
                }
            }
        }
        public void deleteUnemployed(int count)
        {
            for (int i = 0; i < resumes.Count; i++)
            {
                if(unemployeds[count].Phone == resumes[i].Unemployed.Phone)
                {
                    resumes.RemoveAt(count);
                }
            }
            unemployeds.RemoveAt(count);
            writeOnFileUnemployed();
            writeOnFileResume();
        }
        public void sortByFirstnameUnemployed()
        {
            string[] firstnames = new string[unemployeds.Count];
            for (int i = 0; i < firstnames.Length; i++)
            {
                firstnames[i] = unemployeds[i].Firstname;
            }
            Array.Sort(firstnames);
            List<Unemployed> sortedUnemployeds = new List<Unemployed>();
            List<Unemployed> unsortedUnemployeds = unemployeds;
            for (int i = 0; i < unemployeds.Count; i++)
            {
                for (int j = 0; j < unsortedUnemployeds.Count; j++)
                {
                    if (firstnames[i] == unsortedUnemployeds[j].Firstname)
                    {
                        Unemployed unemployed = new Unemployed(unsortedUnemployeds[j].Firstname, unsortedUnemployeds[j].Lastname, unsortedUnemployeds[j].Phone);
                        sortedUnemployeds.Add(unemployed);
                        unsortedUnemployeds[j].Firstname = "";
                        break;
                    }
                }
            }
            unemployeds = sortedUnemployeds;
            writeOnFileUnemployed();
        }
        public void sortByLastnameUnemployed()
        {
            string[] lastname = new string[unemployeds.Count];
            for (int i = 0; i < lastname.Length; i++)
            {
                lastname[i] = unemployeds[i].Lastname;
            }
            Array.Sort(lastname);
            List<Unemployed> sortedUnemployeds = new List<Unemployed>();
            List<Unemployed> unsortedUnemployeds = unemployeds;
            for (int i = 0; i < unemployeds.Count; i++)
            {
                for (int j = 0; j < unsortedUnemployeds.Count; j++)
                {
                    if (lastname[i] == unsortedUnemployeds[j].Lastname)
                    {
                        Unemployed unemployed = new Unemployed(unsortedUnemployeds[j].Firstname, unsortedUnemployeds[j].Lastname, unsortedUnemployeds[j].Phone);
                        sortedUnemployeds.Add(unemployed);
                        unsortedUnemployeds[j].Lastname = "";
                        break;
                    }
                }
            }
            unemployeds = sortedUnemployeds;
            writeOnFileUnemployed();
        }

        //CUSTOMER
        public void addCustomer(string firstname, string lastname, string phone)
        {
            Customer customer;
            try
            {
                customer = new Customer(firstname, lastname, phone);
            }
            catch
            {
                throw new ExceptionWhenInitializeClass("Something wrong with parameters while initialize class in function addCustomer.");
            }
            customers.Add(customer);
            writeOnFileCustomer();
        }
        public string getPhoneOfCustomer(int count)
        {
            return customers[count].Phone;
        }
        public int getCountOfCustomer()
        {
            return customers.Count;
        }
        public string getShortInfoOfCustomer(int count)
        {
            return $"{customers[count].Firstname} {customers[count].Lastname}";
        }
        public string getMoreInfoAboutCustomer(int count)
        {
            string result = $"Firstname: {unemployeds[count].Firstname}; \n" +
                $"Lastname: {unemployeds[count].Lastname}; \n" +
                $"Phone: {unemployeds[count].Phone}; \n";
            return result;
        }
        public void editStringInfoCustomer(int whatToChange, int count, string info)
        {
            switch (whatToChange)
            {
                case 1:
                    customers[count].Firstname = info;
                    break;
                case 2:
                    customers[count].Lastname = info;
                    break;
                case 3:
                    customers[count].Phone = info;
                    break;
            }
            writeOnFileCustomer();
        }
        public void writeOnFileCustomer()
        {
            List<CustomerDAL> customerDALs = new List<CustomerDAL>();
            for (int i = 0; i < customers.Count; i++)
            {
                try
                {
                    CustomerDAL customerDAL = new CustomerDAL(customers[i].Firstname, customers[i].Lastname, customers[i].Phone);
                    customerDALs.Add(customerDAL);
                }
                catch
                {
                    throw new ExceptionWhenIndexOutOfRange("Index out of range in function writeOnFileCustomer.");
                }
            }
            MainInDAL mainInDAL = new MainInDAL(customerDALs);
        }
        public void getInfoFromFileCustomer()
        {
            customers.Clear();
            MainInDAL mainInDAL = new MainInDAL();
            List<CustomerDAL> customerDALs = mainInDAL.ReadFromFileCustomer();
            for (int i = 0; i < customerDALs.Count; i++)
            {
                try
                {
                    Customer customer = new Customer(customerDALs[i].Firstname, customerDALs[i].Lastname, customerDALs[i].Phone);
                    customers.Add(customer);
                }
                catch
                {
                    throw new ExceptionWhenIndexOutOfRange("Index out of range in function getInfoFromFileCustomer.");
                }
            }
        }
        public void deleteCustomer(int count)
        {
            for (int i = 0; i < vacancies.Count; i++)
            {
                if (customers[count].Phone == vacancies[i].Customer.Phone)
                {
                    vacancies.RemoveAt(count);
                }
            }
            customers.RemoveAt(count);
            writeOnFileCustomer();
            writeOnFileVacancy();
        }
        public void sortByFirstnameCustomer()
        {
            string[] firstnames = new string[customers.Count];
            for (int i = 0; i < firstnames.Length; i++)
            {
                firstnames[i] = customers[i].Firstname;
            }
            Array.Sort(firstnames);
            List<Customer> sortedCustomers = new List<Customer>();
            List<Customer> unsortedCustomers = customers;
            for (int i = 0; i < customers.Count; i++)
            {
                for (int j = 0; j < unsortedCustomers.Count; j++)
                {
                    if (firstnames[i] == unsortedCustomers[j].Firstname)
                    {
                        Customer customer = new Customer(unsortedCustomers[j].Firstname, unsortedCustomers[j].Lastname, unsortedCustomers[j].Phone);
                        sortedCustomers.Add(customer);
                        unsortedCustomers[j].Firstname = "";
                        break;
                    }
                }
            }
            customers = sortedCustomers;
            writeOnFileCustomer();
        }
        public void sortByLastnameCustomer()
        {
            string[] lastnames = new string[customers.Count];
            for (int i = 0; i < lastnames.Length; i++)
            {
                lastnames[i] = customers[i].Firstname;
            }
            Array.Sort(lastnames);
            List<Customer> sortedCustomers = new List<Customer>();
            List<Customer> unsortedCustomers = customers;
            for (int i = 0; i < customers.Count; i++)
            {
                for (int j = 0; j < unsortedCustomers.Count; j++)
                {
                    if (lastnames[i] == unsortedCustomers[j].Lastname)
                    {
                        Customer customer = new Customer(unsortedCustomers[j].Firstname, unsortedCustomers[j].Lastname, unsortedCustomers[j].Phone);
                        sortedCustomers.Add(customer);
                        unsortedCustomers[j].Lastname = "";
                        break;
                    }
                }
            }
            customers = sortedCustomers;
            writeOnFileCustomer();
        }
    }
}
