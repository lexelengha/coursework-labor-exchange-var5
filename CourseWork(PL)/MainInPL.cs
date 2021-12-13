using System;
using CourseWork_BLL_;
using System.Text.RegularExpressions;

namespace CourseWork_PL_
{
    class MainInPL
    {
        MainInBLL bllClass = new MainInBLL();
        static void Main(string[] args)
        {
            MainInPL main = new MainInPL();
            string command;
            bool forWhile = true;
            while (forWhile)
            {
                Console.WriteLine("Write one of the command(But exactly as written): ");
                Console.WriteLine("1. UnemployedMenu");
                Console.WriteLine("2. CustomerMenu");
                Console.WriteLine("3. ResumeMenu");
                Console.WriteLine("4. VacancyMenu");
                Console.WriteLine("5. EndWork");
                command = Console.ReadLine();
                switch (command)
                {
                    case "UnemployedMenu":
                        Console.Clear();
                        main.Unemployed_Menu();
                        break;
                    case "CustomerMenu":
                        Console.Clear();
                        main.Customer_Menu();
                        break;
                    case "ResumeMenu":
                        Console.Clear();
                        main.Resume_Menu();
                        break;
                    case "VacancyMenu":
                        Console.Clear();
                        main.Vacancy_Menu();
                        break;
                    case "EndWork":
                        Console.Clear();
                        Console.WriteLine("Work ended.");
                        forWhile = false;
                        break;
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong command, try again.");
                        Console.WriteLine("------------------");
                        break;
                }
            }
        }

        private void Unemployed_Menu()
        {
            bllClass.getInfoFromFileUnemployed();
            bllClass.getInfoFromFileCustomer();
            bllClass.getInfoFromFileResume();
            bllClass.getInfoFromFileVacancy();

            const string regexPhone = @"^([\+]?38[-]?|[0])?[0-9][0-9]{9}$";

            string firstname = "", lastname = "", phone = "", command;

            int numberOfUnemployed;

            bool whileMain = true;
            while (whileMain)
            {
                Console.WriteLine("Write one of the command(But exactly as written): ");
                Console.WriteLine("1. AddUnemployed");
                Console.WriteLine("2. ShowAll");
                Console.WriteLine("3. InfoAboutUnemployed");
                Console.WriteLine("4. EditUnemployed");
                Console.WriteLine("5. DeleteUnemployed");
                Console.WriteLine("6. SortByFirstname");
                Console.WriteLine("7. SortByLastname");
                Console.WriteLine("8. EndWork");
                command = Console.ReadLine();
                switch (command)
                {
                    case "AddUnemployed":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            //FIRSTNAME
                            {
                                Console.Write("Input a firstname of unemployed(if you want cancel adding write CANCEL): ");
                                firstname = Console.ReadLine();
                                if (firstname == "CANCEL")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //LASTNAME
                            {
                                Console.Write("Input a lastname of unemployed(if you want cancel adding write CANCEL): ");
                                lastname = Console.ReadLine();
                                if (lastname == "CANCEL")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //PHONE
                            {
                                bool test = true;
                                bool whileInPhone = true;
                                while (whileInPhone)
                                {
                                    bool phoneSame = false;
                                    Console.Write("Input a phone of unemployed(example [+380123456789]) (if you want cancel write CANCEL): ");
                                    phone = Console.ReadLine();
                                    if (phone == "CANCEL")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        test = false;
                                        break;
                                    }
                                    if (test)
                                    {
                                        if (Regex.IsMatch(phone, regexPhone))
                                        {
                                            numberOfUnemployed = bllClass.getCountOfUnemployeds();
                                            for (int i = 0; i < numberOfUnemployed; i++)
                                            {
                                                if (bllClass.getPhoneOfUnemployed(i) == phone)
                                                {
                                                    phoneSame = true;
                                                }
                                            }
                                            if (phoneSame)
                                            {
                                                Console.WriteLine("Phone the same as in other unemployed, input other.");
                                            }
                                            else
                                            {
                                                whileInPhone = false;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Number is not right, try again.");
                                        }
                                    }
                                }
                                if (!test)
                                {
                                    break;
                                }
                            }
                            bllClass.addUnemployed(firstname, lastname, phone);
                            Console.Clear();
                        } break;
                    case "ShowAll":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfUnemployed = bllClass.getCountOfUnemployeds();
                            if (numberOfUnemployed != 0)
                            {
                                for (int i = 0; i < numberOfUnemployed; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfUnemployeds(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any unemployeds in list.");
                                Console.WriteLine("------------------");
                            }
                        } break;
                    case "InfoAboutUnemployed":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfUnemployed = bllClass.getCountOfUnemployeds();
                            if (numberOfUnemployed != 0)
                            {
                                for (int i = 0; i < numberOfUnemployed; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfUnemployeds(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any unemployeds in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseUnemployedWhile = true;
                            int chooseUnemployed = 0;
                            while (chooseUnemployedWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseUnemployed = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseUnemployed <= 0 || chooseUnemployed > numberOfUnemployed)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine(bllClass.getMoreInfoAboutUnemployed(chooseUnemployed - 1));
                                            Console.WriteLine("------------------");
                                            chooseUnemployedWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseUnemployedWhile = false;
                                }
                            }
                        } break;
                    case "EditUnemployed":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfUnemployed = bllClass.getCountOfUnemployeds();
                            if (numberOfUnemployed != 0)
                            {
                                for (int i = 0; i < numberOfUnemployed; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfUnemployeds(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any unemployeds in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool moreInfoWhile = true;
                            int unemployedCount = 0;
                            bool continueFunc = true;
                            while (moreInfoWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        unemployedCount = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (unemployedCount <= 0 || unemployedCount > numberOfUnemployed)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("------------------");
                                            moreInfoWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    moreInfoWhile = false;
                                    continueFunc = false;
                                }
                            }

                            if (continueFunc)
                            {
                                Console.WriteLine("1. Edit firstname");
                                Console.WriteLine("2. Edit lastname");
                                Console.WriteLine("3. Edit phone");
                                Console.WriteLine("4. CANCEL");
                                Console.WriteLine("------------------");
                                bool chooseWhatToEditWhile = true;
                                while (chooseWhatToEditWhile)
                                {
                                    Console.Write("Input a number what to choose: ");
                                    string whatChange = Console.ReadLine();
                                    switch (whatChange)
                                    {
                                        case "1":{
                                                Console.Write("Input a firstname of client(if you want cancel adding write CANCEL): ");
                                                firstname = Console.ReadLine();
                                                if (firstname == "CANCEL")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You canceled.");
                                                    Console.WriteLine("------------------");
                                                    chooseWhatToEditWhile = false;
                                                    continueFunc = false;
                                                    break;
                                                }
                                                bllClass.editStringInfoUnemployed(1, unemployedCount - 1, firstname);
                                                chooseWhatToEditWhile = false;
                                                continueFunc = false;
                                                Console.Clear();
                                                Console.WriteLine("You edited firstname");
                                                Console.WriteLine("------------------");
                                            } break;
                                        case "2":{
                                                Console.Write("Input a lastname of client(if you want cancel adding write CANCEL): ");
                                                lastname = Console.ReadLine();
                                                if (lastname == "CANCEL")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You canceled.");
                                                    Console.WriteLine("------------------");
                                                    chooseWhatToEditWhile = false;
                                                    continueFunc = false;
                                                    break;
                                                }
                                                bllClass.editStringInfoUnemployed(2, unemployedCount - 1, lastname);
                                                chooseWhatToEditWhile = false;
                                                continueFunc = false;
                                                Console.Clear();
                                                Console.WriteLine("You edited lastname");
                                                Console.WriteLine("------------------");
                                            } break;
                                        case "3":{
                                                bool cont = true;
                                                bool whileInPhone = true;
                                                while (whileInPhone)
                                                {
                                                    bool phoneSame = false;
                                                    Console.Write("Input a phone of client(example [+380123456789]) (if you want cancel write CANCEL): ");
                                                    phone = Console.ReadLine();
                                                    if (phone == "CANCEL")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("You canceled.");
                                                        Console.WriteLine("------------------");
                                                        chooseWhatToEditWhile = false;
                                                        cont = false;
                                                        break;
                                                    }
                                                    if (Regex.IsMatch(phone, regexPhone))
                                                    {
                                                        numberOfUnemployed = bllClass.getCountOfUnemployeds();
                                                        int numberOfCustomers = bllClass.getCountOfCustomer();
                                                        for (int i = 0; i < numberOfUnemployed; i++)
                                                        {
                                                            if (bllClass.getPhoneOfUnemployed(i) == phone && unemployedCount - 1 != i)
                                                            {
                                                                phoneSame = true;
                                                            }
                                                        }
                                                        for (int i = 0; i < numberOfCustomers; i++)
                                                        {
                                                            if (bllClass.getPhoneOfCustomer(i) == phone)
                                                            {
                                                                phoneSame = true;
                                                            }
                                                        }
                                                        if (phoneSame)
                                                        {
                                                            Console.WriteLine("Phone the same as in other unemployed, input other.");
                                                        }
                                                        else
                                                        {
                                                            whileInPhone = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Number is not right, try again.");
                                                    }
                                                    if (cont)
                                                    {
                                                        bllClass.editStringInfoUnemployed(3, unemployedCount - 1, phone);
                                                        whileInPhone = false;
                                                        chooseWhatToEditWhile = false;
                                                        Console.Clear();
                                                        Console.WriteLine("You edited phone");
                                                        Console.WriteLine("------------------");
                                                    }
                                                }
                                            } break;
                                        case "4":
                                            Console.Clear();
                                            chooseWhatToEditWhile = false;
                                            continueFunc = false;
                                            break;
                                        default:
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("Wrong command, try again.");
                                            Console.WriteLine("------------------");
                                            break;
                                    }
                                }
                            }
                        } break;
                    case "DeleteUnemployed":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfUnemployed = bllClass.getCountOfUnemployeds();
                            if (numberOfUnemployed != 0)
                            {
                                for (int i = 0; i < numberOfUnemployed; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfUnemployeds(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any unemployeds in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseUnemployedToDeleteWhile = true;
                            int chooseUnemployedToDelete = 0;
                            while (chooseUnemployedToDeleteWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseUnemployedToDelete = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseUnemployedToDelete <= 0 || chooseUnemployedToDelete > numberOfUnemployed)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            bllClass.deleteUnemployed(chooseUnemployedToDelete - 1);
                                            Console.WriteLine("You deleted unemployed from list.");
                                            Console.WriteLine("------------------");
                                            chooseUnemployedToDeleteWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseUnemployedToDeleteWhile = false;
                                }
                            }
                        } break;
                    case "SortByFirstname":
                        bllClass.sortByFirstnameUnemployed();
                        Console.Clear();
                        Console.WriteLine("Unemployeds was sorted for firstname");
                        Console.WriteLine("------------------");
                        break;
                    case "SortByLastname":
                        bllClass.sortByLastnameUnemployed();
                        Console.Clear();
                        Console.WriteLine("Unemployeds was sorted for lastname");
                        Console.WriteLine("------------------");
                        break;
                    case "EndWork":
                        Console.Clear();
                        whileMain = false;
                        break;
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong command, try again.");
                        Console.WriteLine("------------------");
                        break;
                }
            }
        }

        private void Customer_Menu()
        {
            bllClass.getInfoFromFileUnemployed();
            bllClass.getInfoFromFileCustomer();
            bllClass.getInfoFromFileResume();
            bllClass.getInfoFromFileVacancy();

            const string regexPhone = @"^([\+]?38[-]?|[0])?[0-9][0-9]{9}$";

            string firstname = "", lastname = "", phone = "", categoryOfWork = "", command;

            int numberOfCustomers;

            bool whileMain = true;
            while (whileMain)
            {
                Console.WriteLine("Write one of the command(But exactly as written): ");
                Console.WriteLine("1. AddCustomer");
                Console.WriteLine("2. ShowAll");
                Console.WriteLine("3. InfoAboutCustomer");
                Console.WriteLine("4. EditCustomer");
                Console.WriteLine("5. DeleteCustomer");
                Console.WriteLine("6. SortByFirstname");
                Console.WriteLine("7. SortByLastname");
                Console.WriteLine("8. EndWork");
                command = Console.ReadLine();
                switch (command)
                {
                    case "AddCustomer":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            //FIRSTNAME
                            {
                                Console.Write("Input a firstname of customer(if you want cancel adding write CANCEL): ");
                                firstname = Console.ReadLine();
                                if (firstname == "CANCEL")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //LASTNAME
                            {
                                Console.Write("Input a lastname of customer(if you want cancel adding write CANCEL): ");
                                lastname = Console.ReadLine();
                                if (lastname == "CANCEL")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //PHONE
                            {
                                bool test = true;
                                bool whileInPhone = true;
                                while (whileInPhone)
                                {
                                    bool phoneSame = false;
                                    Console.Write("Input a phone of customer(example [+380123456789]) (if you want cancel write CANCEL): ");
                                    phone = Console.ReadLine();
                                    if (phone == "CANCEL")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        test = false;
                                        break;
                                    }
                                    if (test)
                                    {
                                        if (Regex.IsMatch(phone, regexPhone))
                                        {
                                            numberOfCustomers = bllClass.getCountOfCustomer();
                                            int numberOfUnemployeds = bllClass.getCountOfUnemployeds();
                                            for (int i = 0; i < numberOfCustomers; i++)
                                            {
                                                if (bllClass.getPhoneOfCustomer(i) == phone)
                                                {
                                                    phoneSame = true;
                                                }
                                            }
                                            for (int i = 0; i < numberOfUnemployeds; i++)
                                            {
                                                if (bllClass.getPhoneOfUnemployed(i) == phone)
                                                {
                                                    phoneSame = true;
                                                }
                                            }
                                            if (phoneSame)
                                            {
                                                Console.WriteLine("Phone the same as in other unemployed, input other.");
                                            }
                                            else
                                            {
                                                whileInPhone = false;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Number is not right, try again.");
                                        }
                                    }
                                }
                                if (!test)
                                {
                                    break;
                                }
                            }                       
                            bllClass.addCustomer(firstname, lastname, phone);
                            Console.Clear();
                        } break;
                    case "ShowAll":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfCustomers = bllClass.getCountOfCustomer();
                            if (numberOfCustomers != 0)
                            {
                                for (int i = 0; i < numberOfCustomers; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfCustomer(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any customers in list.");
                                Console.WriteLine("------------------");
                            }
                        } break;
                    case "InfoAboutCustomer":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfCustomers = bllClass.getCountOfCustomer();
                            if (numberOfCustomers != 0)
                            {
                                for (int i = 0; i < numberOfCustomers; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfCustomer(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any customers in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseCustomerWhile = true;
                            int chooseCustomer = 0;
                            while (chooseCustomerWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseCustomer = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseCustomer <= 0 || chooseCustomer > numberOfCustomers)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine(bllClass.getMoreInfoAboutCustomer(chooseCustomer - 1));
                                            Console.WriteLine("------------------");
                                            chooseCustomerWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseCustomerWhile = false;
                                }
                            }
                        } break;
                    case "EditCustomer":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfCustomers = bllClass.getCountOfCustomer();
                            if (numberOfCustomers != 0)
                            {
                                for (int i = 0; i < numberOfCustomers; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfCustomer(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any customers in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool moreInfoWhile = true;
                            int customerCount = 0;
                            bool continueFunc = true;
                            while (moreInfoWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        customerCount = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (customerCount <= 0 || customerCount > numberOfCustomers)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("------------------");
                                            moreInfoWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    moreInfoWhile = false;
                                    continueFunc = false;
                                }
                            }

                            if (continueFunc)
                            {
                                Console.WriteLine("1. Edit firstname");
                                Console.WriteLine("2. Edit lastname");
                                Console.WriteLine("3. Edit phone");
                                Console.WriteLine("4. CANCEL");
                                Console.WriteLine("------------------");
                                bool chooseWhatToEditWhile = true;
                                while (chooseWhatToEditWhile)
                                {
                                    Console.Write("Input a number what to choose: ");
                                    string whatChange = Console.ReadLine();
                                    switch (whatChange)
                                    {
                                        case "1":
                                            {
                                                Console.Write("Input a firstname of customer(if you want cancel adding write CANCEL): ");
                                                firstname = Console.ReadLine();
                                                if (firstname == "CANCEL")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You canceled.");
                                                    Console.WriteLine("------------------");
                                                    chooseWhatToEditWhile = false;
                                                    continueFunc = false;
                                                    break;
                                                }
                                                bllClass.editStringInfoCustomer(1, customerCount - 1, firstname);
                                                chooseWhatToEditWhile = false;
                                                continueFunc = false;
                                                Console.Clear();
                                                Console.WriteLine("You edited firstname");
                                                Console.WriteLine("------------------");
                                            }
                                            break;
                                        case "2":
                                            {
                                                Console.Write("Input a lastname of customer(if you want cancel adding write CANCEL): ");
                                                lastname = Console.ReadLine();
                                                if (lastname == "CANCEL")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You canceled.");
                                                    Console.WriteLine("------------------");
                                                    chooseWhatToEditWhile = false;
                                                    continueFunc = false;
                                                    break;
                                                }
                                                bllClass.editStringInfoCustomer(2, customerCount - 1, lastname);
                                                chooseWhatToEditWhile = false;
                                                continueFunc = false;
                                                Console.Clear();
                                                Console.WriteLine("You edited lastname");
                                                Console.WriteLine("------------------");
                                            }
                                            break;
                                        case "3":
                                            {
                                                bool cont = true;
                                                bool whileInPhone = true;
                                                while (whileInPhone)
                                                {
                                                    bool phoneSame = false;
                                                    Console.Write("Input a phone of customer(example [+380123456789]) (if you want cancel write CANCEL): ");
                                                    phone = Console.ReadLine();
                                                    if (phone == "CANCEL")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("You canceled.");
                                                        Console.WriteLine("------------------");
                                                        chooseWhatToEditWhile = false;
                                                        cont = false;
                                                        break;
                                                    }
                                                    if (Regex.IsMatch(phone, regexPhone))
                                                    {
                                                        int numberOfUnemployed = bllClass.getCountOfUnemployeds();
                                                        numberOfCustomers = bllClass.getCountOfCustomer();
                                                        for (int i = 0; i < numberOfUnemployed; i++)
                                                        {
                                                            if (bllClass.getPhoneOfUnemployed(i) == phone && customerCount - 1 != i)
                                                            {
                                                                phoneSame = true;
                                                            }
                                                        }
                                                        for (int i = 0; i < numberOfCustomers; i++)
                                                        {
                                                            if (bllClass.getPhoneOfCustomer(i) == phone)
                                                            {
                                                                phoneSame = true;
                                                            }
                                                        }
                                                        if (phoneSame)
                                                        {
                                                            Console.WriteLine("Phone the same as in other unemployed or customer, input other.");
                                                        }
                                                        else
                                                        {
                                                            whileInPhone = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Number is not right, try again.");
                                                    }
                                                    if (cont)
                                                    {
                                                        bllClass.editStringInfoCustomer(3, customerCount - 1, phone);
                                                        whileInPhone = false;
                                                        chooseWhatToEditWhile = false;
                                                        Console.Clear();
                                                        Console.WriteLine("You edited phone");
                                                        Console.WriteLine("------------------");
                                                    }
                                                }
                                            }
                                            break;
                                        case "4":
                                            Console.Clear();
                                            chooseWhatToEditWhile = false;
                                            continueFunc = false;
                                            break;
                                        default:
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("Wrong command, try again.");
                                            Console.WriteLine("------------------");
                                            break;
                                    }
                                }
                            }
                        } break;
                    case "DeleteCustomer":
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfCustomers = bllClass.getCountOfCustomer();
                            if (numberOfCustomers != 0)
                            {
                                for (int i = 0; i < numberOfCustomers; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfCustomer(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any customers in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseUnemployedToDeleteWhile = true;
                            int chooseUnemployedToDelete = 0;
                            while (chooseUnemployedToDeleteWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseUnemployedToDelete = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseUnemployedToDelete <= 0 || chooseUnemployedToDelete > numberOfCustomers)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            bllClass.deleteUnemployed(chooseUnemployedToDelete - 1);
                                            Console.WriteLine("You deleted unemployed from list.");
                                            Console.WriteLine("------------------");
                                            chooseUnemployedToDeleteWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseUnemployedToDeleteWhile = false;
                                }
                            }
                        }
                        break;
                    case "SortByFirstname":
                        bllClass.sortByFirstnameUnemployed();
                        Console.Clear();
                        Console.WriteLine("Unemployeds was sorted for firstname");
                        Console.WriteLine("------------------");
                        break;
                    case "SortByLastname":
                        bllClass.sortByLastnameUnemployed();
                        Console.Clear();
                        Console.WriteLine("Unemployeds was sorted for lastname");
                        Console.WriteLine("------------------");
                        break;
                    case "EndWork":
                        Console.Clear();
                        whileMain = false;
                        break;
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong command, try again.");
                        Console.WriteLine("------------------");
                        break;
                }
            }
        }

        private void Resume_Menu()
        {
            bllClass.getInfoFromFileUnemployed();
            bllClass.getInfoFromFileCustomer();
            bllClass.getInfoFromFileResume();
            bllClass.getInfoFromFileVacancy();

            string categoryOfWork = "", command;
            int desirableSalary = 0, experience = 0;
            string additionalInfo = "";

            int numberOfUnemployed;
            int numberOfResume;
            int chooseUnemployed = 0;

            bool whileMain = true;
            while (whileMain)
            {
                Console.WriteLine("Write one of the command(But exactly as written): ");
                Console.WriteLine("1. AddResume");
                Console.WriteLine("2. InfoAboutResume");
                Console.WriteLine("3. EditResume");
                Console.WriteLine("4. DeleteResume");
                Console.WriteLine("5. SortByCategory");
                Console.WriteLine("6. EndWork");
                command = Console.ReadLine();
                switch (command)
                {
                    case "AddResume":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfUnemployed = bllClass.getCountOfUnemployeds();
                            if (numberOfUnemployed != 0)
                            {
                                for (int i = 0; i < numberOfUnemployed; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfUnemployeds(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any unemployeds in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseUnemployedWhile = true;
                            chooseUnemployed = 0;
                            while (chooseUnemployedWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseUnemployed = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseUnemployed <= 0 || chooseUnemployed > numberOfUnemployed)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.WriteLine("------------------");
                                            chooseUnemployedWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseUnemployedWhile = false;
                                }
                            }
                            //CATEGORY
                            {
                                bool con = true;
                                bool categoryWhile = true;
                                while (categoryWhile)
                                {
                                    Console.WriteLine("Input a one category of work(if you want cancel write CANCEL): ");
                                    Console.WriteLine("1. IT");
                                    Console.WriteLine("2. DESIGN");
                                    Console.WriteLine("3. ACCOUNTING");
                                    Console.WriteLine("4. MEDIA");
                                    Console.WriteLine("5. SELLING");
                                    categoryOfWork = Console.ReadLine();
                                    switch (categoryOfWork)
                                    {
                                        case "IT":
                                            categoryWhile = false;
                                            break;
                                        case "DESIGN":
                                            categoryWhile = false;
                                            break;
                                        case "ACCOUNTING":
                                            categoryWhile = false;
                                            break;
                                        case "MEDIA":
                                            categoryWhile = false;
                                            break;
                                        case "SELLING":
                                            categoryWhile = false;
                                            break;
                                        case "CANCEL":
                                            Console.Clear();
                                            Console.WriteLine("You canceled addinng.");
                                            Console.WriteLine("------------------");
                                            categoryWhile = false;
                                            con = false;
                                            break;
                                        default:
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("Wrong command, try again.");
                                            Console.WriteLine("------------------");
                                            break;
                                    }
                                }
                                if (!con)
                                {
                                    break;
                                }
                            }
                            //DESIRABLE SALARY
                            {
                                bool contSalary = true;
                                bool salaryWhile = true;
                                while (salaryWhile)
                                {
                                    Console.Write("Input a desirable salary(if you want cancel adding write CANCEL): ");
                                    string chooser = Console.ReadLine();
                                    if (chooser != "CANCEL")
                                    {
                                        try
                                        {
                                            desirableSalary = Convert.ToInt32(chooser);
                                            salaryWhile = false;
                                        }
                                        catch (Exception e)
                                        {
                                            new ExceptionInputNumberAreWrong(e.Message);
                                            Console.WriteLine("Try again.");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        contSalary = false;
                                        salaryWhile = false;
                                    }
                                }
                                if (!contSalary)
                                {
                                    break;
                                }
                            }
                            //Experience
                            {
                                bool contExp = true;
                                bool experienceWhile = true;
                                while (experienceWhile)
                                {
                                    Console.Write("Input a experience(if you want cancel adding write CANCEL): ");
                                    string chooser = Console.ReadLine();
                                    if (chooser != "CANCEL")
                                    {
                                        try
                                        {
                                            experience = Convert.ToInt32(chooser);
                                            experienceWhile = false;
                                        }
                                        catch (Exception e)
                                        {
                                            new ExceptionInputNumberAreWrong(e.Message);
                                            Console.WriteLine("Try again.");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        experienceWhile = false;
                                        contExp = false;
                                    }
                                }
                                if (!contExp)
                                {
                                    break;
                                }
                            }
                            //Additional info
                            {
                                bool contExp = true;
                                bool addWhile = true;
                                while (addWhile)
                                {
                                    Console.Write("Input additional info(if you want cancel adding write CANCEL): ");
                                    additionalInfo = Console.ReadLine();
                                    if (additionalInfo != "CANCEL")
                                    {
                                        addWhile = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        addWhile = false;
                                        contExp = false;
                                    }
                                }
                                if (!contExp)
                                {
                                    break;
                                }
                            }
                            bllClass.addResume(chooseUnemployed - 1,categoryOfWork, experience, desirableSalary, additionalInfo);
                            Console.Clear();
                        } break;
                    case "InfoAboutResume":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfResume = bllClass.getCountOfResume();
                            if (numberOfResume != 0)
                            {
                                for (int i = 0; i < numberOfResume; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoResume(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any resume in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseResumeWhile = true;
                            int chooseResume = 0;
                            while (chooseResumeWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseResume = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseResume <= 0 || chooseResume > numberOfResume)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine(bllClass.getMoreInfoAboutResume(chooseResume - 1));
                                            Console.WriteLine("------------------");
                                            chooseResumeWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseResumeWhile = false;
                                }
                            }
                        } break;
                    case "EditResume":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfResume = bllClass.getCountOfResume();
                            if (numberOfResume != 0)
                            {
                                for (int i = 0; i < numberOfResume; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoResume(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any resume in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool moreInfoWhile = true;
                            int resumeCount = 0;
                            bool continueFunc = true;
                            while (moreInfoWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        resumeCount = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (resumeCount <= 0 || resumeCount > numberOfResume)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("------------------");
                                            moreInfoWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    moreInfoWhile = false;
                                    continueFunc = false;
                                }
                            }

                            if (continueFunc)
                            {
                                Console.WriteLine("1. Edit category of work");
                                Console.WriteLine("2. Edit experience");
                                Console.WriteLine("3. Edit desirable salary");
                                Console.WriteLine("4. Edit additional info");
                                Console.WriteLine("5. CANCEL");
                                Console.WriteLine("------------------");
                                bool chooseWhatToEditWhile = true;
                                while (chooseWhatToEditWhile)
                                {
                                    Console.Write("Input a number what to choose: ");
                                    string whatChange = Console.ReadLine();
                                    switch (whatChange)
                                    {
                                        case "1":
                                            {
                                                bool categoryWhile = true;
                                                while (categoryWhile)
                                                {
                                                    Console.WriteLine("Input a one category of work(write category not a number)(if you want cancel write CANCEL): ");
                                                    Console.WriteLine("1. IT");
                                                    Console.WriteLine("2. DESIGN");
                                                    Console.WriteLine("3. ACCOUNTING");
                                                    Console.WriteLine("4. MEDIA");
                                                    Console.WriteLine("5. SELLING");
                                                    categoryOfWork = Console.ReadLine();
                                                    switch (categoryOfWork)
                                                    {
                                                        case "IT":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoResume(1, resumeCount - 1, categoryOfWork);
                                                            break;
                                                        case "DESIGN":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoUnemployed(1, resumeCount - 1, categoryOfWork);
                                                            break;
                                                        case "ACCOUNTING":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoUnemployed(1, resumeCount - 1, categoryOfWork);
                                                            break;
                                                        case "MEDIA":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoUnemployed(1, resumeCount - 1, categoryOfWork);
                                                            break;
                                                        case "SELLING":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoUnemployed(1, resumeCount - 1, categoryOfWork);
                                                            break;
                                                        case "CANCEL":
                                                            Console.Clear();
                                                            Console.WriteLine("You canceled addinng.");
                                                            Console.WriteLine("------------------");
                                                            categoryWhile = false;
                                                            chooseWhatToEditWhile = false;
                                                            break;
                                                        default:
                                                            Console.WriteLine("------------------");
                                                            Console.WriteLine("Wrong command, try again.");
                                                            Console.WriteLine("------------------");
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                        case "2":
                                            {
                                                bool contExper = true;
                                                bool experieWhile = true;
                                                while (experieWhile)
                                                {
                                                    Console.Write("Input a experience(if you want cancel adding write CANCEL): ");
                                                    string chooser = Console.ReadLine();
                                                    if (chooser != "CANCEL")
                                                    {
                                                        try
                                                        {
                                                            experience = Convert.ToInt32(chooser);
                                                            experieWhile = false;
                                                            chooseWhatToEditWhile = false;
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            new ExceptionInputNumberAreWrong(e.Message);
                                                            Console.WriteLine("Try again.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("You canceled.");
                                                        Console.WriteLine("------------------");
                                                        contExper = false;
                                                        experieWhile = false;
                                                        chooseWhatToEditWhile = false;
                                                    }
                                                }
                                                if (!contExper)
                                                {
                                                    break;
                                                }
                                                Console.Clear();
                                                Console.WriteLine("You edited experience");
                                                Console.WriteLine("------------------");
                                                bllClass.editIntInfoResume(1, resumeCount - 1, experience);
                                            }
                                            break;
                                        case "3":
                                            {
                                                bool contSalary = true;
                                                bool salaryWhile = true;
                                                while (salaryWhile)
                                                {
                                                    Console.Write("Input a desirable salary(if you want cancel adding write CANCEL): ");
                                                    string chooser = Console.ReadLine();
                                                    if (chooser != "CANCEL")
                                                    {
                                                        try
                                                        {
                                                            desirableSalary = Convert.ToInt32(chooser);
                                                            salaryWhile = false;
                                                            chooseWhatToEditWhile = false;
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            new ExceptionInputNumberAreWrong(e.Message);
                                                            Console.WriteLine("Try again.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("You canceled.");
                                                        Console.WriteLine("------------------");
                                                        contSalary = false;
                                                        salaryWhile = false;
                                                        chooseWhatToEditWhile = false;
                                                    }
                                                }
                                                if (!contSalary)
                                                {
                                                    break;
                                                }
                                                Console.Clear();
                                                Console.WriteLine("You edited desirable salary");
                                                Console.WriteLine("------------------");
                                                bllClass.editIntInfoResume(2, resumeCount - 1, desirableSalary);
                                            }
                                            break;
                                        case "4":
                                            {
                                                bool contExp = true;
                                                bool addWhile = true;
                                                while (addWhile)
                                                {
                                                    Console.Write("Input additional info(if you want cancel adding write CANCEL): ");
                                                    additionalInfo = Console.ReadLine();
                                                    if (additionalInfo != "CANCEL")
                                                    {
                                                        addWhile = false;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("You canceled addinng.");
                                                        Console.WriteLine("------------------");
                                                        addWhile = false;
                                                        contExp = false;
                                                    }
                                                }
                                                if (!contExp)
                                                {
                                                    break;
                                                }
                                                Console.Clear();
                                                Console.WriteLine("You edited additional info");
                                                Console.WriteLine("------------------");
                                                bllClass.editStringInfoResume(2, resumeCount - 1, additionalInfo);
                                            }
                                            break;
                                        case "5":
                                            Console.Clear();
                                            chooseWhatToEditWhile = false;
                                            continueFunc = false;
                                            break;
                                        default:
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("Wrong command, try again.");
                                            Console.WriteLine("------------------");
                                            break;
                                    }
                                }
                            }
                        } break;
                    case "DeleteResume":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfResume = bllClass.getCountOfResume();
                            if (numberOfResume != 0)
                            {
                                for (int i = 0; i < numberOfResume; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoResume(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any resume in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseResumeoDeleteWhile = true;
                            int chooseResumeToDelete = 0;
                            while (chooseResumeoDeleteWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseResumeToDelete = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseResumeToDelete <= 0 || chooseResumeToDelete > numberOfResume)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            bllClass.deleteResume(chooseResumeToDelete - 1);
                                            Console.WriteLine("You deleted resume from list.");
                                            Console.WriteLine("------------------");
                                            chooseResumeoDeleteWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseResumeoDeleteWhile = false;
                                }
                            }
                        } break;
                    case "SortByCategory":
                        Console.Clear();
                        bool con1 = true;
                        bool categoryWhile1 = true;
                        numberOfResume = bllClass.getCountOfResume();
                        while (categoryWhile1)
                        {
                            Console.WriteLine("Input a one category of work(if you want cancel write CANCEL): ");
                            Console.WriteLine("1. IT");
                            Console.WriteLine("2. DESIGN");
                            Console.WriteLine("3. ACCOUNTING");
                            Console.WriteLine("4. MEDIA");
                            Console.WriteLine("5. SELLING");
                            categoryOfWork = Console.ReadLine();
                            switch (categoryOfWork)
                            {
                                case "IT":
                                    categoryWhile1 = false;
                                    break;
                                case "DESIGN":
                                    categoryWhile1 = false;
                                    break;
                                case "ACCOUNTING":
                                    categoryWhile1 = false;
                                    break;
                                case "MEDIA":
                                    categoryWhile1 = false;
                                    break;
                                case "SELLING":
                                    categoryWhile1 = false;
                                    break;
                                case "CANCEL":
                                    Console.Clear();
                                    Console.WriteLine("You canceled addinng.");
                                    Console.WriteLine("------------------");
                                    categoryWhile1 = false;
                                    con1 = false;
                                    break;
                                default:
                                    Console.WriteLine("------------------");
                                    Console.WriteLine("Wrong command, try again.");
                                    Console.WriteLine("------------------");
                                    break;
                            }
                        }
                        if (!con1)
                        {
                            break;
                        }
                        Console.Clear();
                        int count = 1;
                        bool nothing = true;
                        for (int i = 0; i < numberOfResume; i++)
                        {
                            if(bllClass.getCategoryOfWorkResume(i) == categoryOfWork)
                            {
                                nothing = false;
                                Console.WriteLine($"{count}. {bllClass.getShortInfoResume(i)}");
                                count++;
                            }
                        }
                        if (nothing)
                        {
                            Console.Clear();
                            Console.WriteLine("You dont have any resume in this category");
                        }
                        Console.WriteLine("------------------");
                        break;
                    case "EndWork":
                        Console.Clear();
                        whileMain = false;
                        break;
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong command, try again.");
                        Console.WriteLine("------------------");
                        break;
                }
            }
        }

        private void Vacancy_Menu()
        {
            bllClass.getInfoFromFileUnemployed();
            bllClass.getInfoFromFileCustomer();
            bllClass.getInfoFromFileResume();
            bllClass.getInfoFromFileVacancy();

            string categoryOfWork = "", command;
            int desirableSalary = 0, experience = 0;
            bool isDistance = true, isCarrerGrowth = true;
            string additionalInfo = "";

            int numberOfCustomers;
            int numberOfVacancy;
            int chooseCustomers = 0;

            bool whileMain = true;
            while (whileMain)
            {
                Console.WriteLine("Write one of the command(But exactly as written): ");
                Console.WriteLine("1. AddVacancy");
                Console.WriteLine("2. InfoAboutVacancy");
                Console.WriteLine("3. EditVacancy");
                Console.WriteLine("4. DeleteVacancy");
                Console.WriteLine("5. SortByCategory");
                Console.WriteLine("6. EndWork");
                command = Console.ReadLine();
                switch (command)
                {
                    case "AddVacancy":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfCustomers = bllClass.getCountOfCustomer();
                            if (numberOfCustomers != 0)
                            {
                                for (int i = 0; i < numberOfCustomers; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoOfCustomer(i)} {bllClass.getPhoneOfCustomer(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any customers in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseCustomerWhile = true;
                            chooseCustomers = 0;
                            while (chooseCustomerWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseCustomers = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseCustomers <= 0 || chooseCustomers > numberOfCustomers)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.WriteLine("------------------");
                                            chooseCustomerWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseCustomerWhile = false;
                                }
                            }
                            //CATEGORY
                            {
                                bool con = true;
                                bool categoryWhile = true;
                                while (categoryWhile)
                                {
                                    Console.WriteLine("Input a one category of work(if you want cancel write CANCEL): ");
                                    Console.WriteLine("1. IT");
                                    Console.WriteLine("2. DESIGN");
                                    Console.WriteLine("3. ACCOUNTING");
                                    Console.WriteLine("4. MEDIA");
                                    Console.WriteLine("5. SELLING");
                                    Console.WriteLine("6. CANCEL");
                                    categoryOfWork = Console.ReadLine();
                                    switch (categoryOfWork)
                                    {
                                        case "IT":
                                            categoryWhile = false;
                                            break;
                                        case "DESIGN":
                                            categoryWhile = false;
                                            break;
                                        case "ACCOUNTING":
                                            categoryWhile = false;
                                            break;
                                        case "MEDIA":
                                            categoryWhile = false;
                                            break;
                                        case "SELLING":
                                            categoryWhile = false;
                                            break;
                                        case "CANCEL":
                                            Console.Clear();
                                            Console.WriteLine("You canceled addinng.");
                                            Console.WriteLine("------------------");
                                            categoryWhile = false;
                                            con = false;
                                            break;
                                        default:
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("Wrong command, try again.");
                                            Console.WriteLine("------------------");
                                            break;
                                    }
                                }
                                if (!con)
                                {
                                    break;
                                }
                            }
                            //DESIRABLE SALARY
                            {
                                bool contSalary = true;
                                bool salaryWhile = true;
                                while (salaryWhile)
                                {
                                    Console.Write("Input a desirable salary(if you want cancel adding write CANCEL): ");
                                    string chooser = Console.ReadLine();
                                    if (chooser != "CANCEL")
                                    {
                                        try
                                        {
                                            desirableSalary = Convert.ToInt32(chooser);
                                            salaryWhile = false;
                                        }
                                        catch (Exception e)
                                        {
                                            new ExceptionInputNumberAreWrong(e.Message);
                                            Console.WriteLine("Try again.");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        contSalary = false;
                                        salaryWhile = false;
                                    }
                                }
                                if (!contSalary)
                                {
                                    break;
                                }
                            }
                            //Experience
                            {
                                bool contExp = true;
                                bool experienceWhile = true;
                                while (experienceWhile)
                                {
                                    Console.Write("Input a minimum experience(if you want cancel adding write CANCEL): ");
                                    string chooser = Console.ReadLine();
                                    if (chooser != "CANCEL")
                                    {
                                        try
                                        {
                                            experience = Convert.ToInt32(chooser);
                                            experienceWhile = false;
                                        }
                                        catch (Exception e)
                                        {
                                            new ExceptionInputNumberAreWrong(e.Message);
                                            Console.WriteLine("Try again.");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        experienceWhile = false;
                                        contExp = false;
                                    }
                                }
                                if (!contExp)
                                {
                                    break;
                                }
                            }
                            //DISTANCE WORK
                            {
                                bool conDist = true;
                                bool categoryWhileDist = true;
                                while (categoryWhileDist)
                                {
                                    Console.WriteLine("Input if job have a distance work(if you want cancel write CANCEL): ");
                                    Console.WriteLine("1. YES");
                                    Console.WriteLine("2. NO");
                                    Console.WriteLine("3. CANCEL");
                                    categoryOfWork = Console.ReadLine();
                                    switch (categoryOfWork)
                                    {
                                        case "YES":
                                            isDistance = true;
                                            categoryWhileDist = false;
                                            break;
                                        case "NO":
                                            isDistance = false;
                                            categoryWhileDist = false;
                                            break;
                                        case "CANCEL":
                                            Console.Clear();
                                            Console.WriteLine("You canceled addinng.");
                                            Console.WriteLine("------------------");
                                            categoryWhileDist = false;
                                            conDist = false;
                                            break;
                                        default:
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("Wrong command, try again.");
                                            Console.WriteLine("------------------");
                                            break;
                                    }
                                }
                                if (!conDist)
                                {
                                    break;
                                }
                            }
                            //CARRER GROWTH
                            {
                                bool conCar = true;
                                bool categoryWhileCar = true;
                                while (categoryWhileCar)
                                {
                                    Console.WriteLine("Input if job have a carrer growth(if you want cancel write CANCEL): ");
                                    Console.WriteLine("1. YES");
                                    Console.WriteLine("2. NO");
                                    Console.WriteLine("3. CANCEL");
                                    categoryOfWork = Console.ReadLine();
                                    switch (categoryOfWork)
                                    {
                                        case "YES":
                                            isCarrerGrowth = true;
                                            categoryWhileCar = false;
                                            break;
                                        case "NO":
                                            isCarrerGrowth = false;
                                            categoryWhileCar = false;
                                            break;
                                        case "CANCEL":
                                            Console.Clear();
                                            Console.WriteLine("You canceled addinng.");
                                            Console.WriteLine("------------------");
                                            categoryWhileCar = false;
                                            conCar = false;
                                            break;
                                        default:
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("Wrong command, try again.");
                                            Console.WriteLine("------------------");
                                            break;
                                    }
                                }
                                if (!conCar)
                                {
                                    break;
                                }
                            }
                            //Additional info
                            {
                                bool contExp = true;
                                bool addWhile = true;
                                while (addWhile)
                                {
                                    Console.Write("Input additional info(if you want cancel adding write CANCEL): ");
                                    additionalInfo = Console.ReadLine();
                                    if (additionalInfo != "CANCEL")
                                    {
                                        addWhile = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        addWhile = false;
                                        contExp = false;
                                    }
                                }
                                if (!contExp)
                                {
                                    break;
                                }
                            }
                            bllClass.addVacancy(chooseCustomers - 1, categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
                            Console.Clear();
                        } break;
                    case "InfoAboutVacancy":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfVacancy = bllClass.getCountOfVacancy();
                            if (numberOfVacancy != 0)
                            {
                                for (int i = 0; i < numberOfVacancy; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoVacancy(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any vacancy in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseVacancyWhile = true;
                            int chooseVacancy = 0;
                            while (chooseVacancyWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseVacancy = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseVacancy <= 0 || chooseVacancy > numberOfVacancy)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine(bllClass.getMoreInfoAboutVacancy(chooseVacancy - 1));
                                            Console.WriteLine("------------------");
                                            chooseVacancyWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseVacancyWhile = false;
                                }
                            }
                        } break;
                    case "EditVacancy":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfVacancy = bllClass.getCountOfVacancy();
                            if (numberOfVacancy != 0)
                            {
                                for (int i = 0; i < numberOfVacancy; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoVacancy(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any vacancy in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool moreInfoWhile = true;
                            int vacancyCount = 0;
                            bool continueFunc = true;
                            while (moreInfoWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        vacancyCount = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (vacancyCount <= 0 || vacancyCount > numberOfVacancy)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("------------------");
                                            moreInfoWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    moreInfoWhile = false;
                                    continueFunc = false;
                                }
                            }

                            if (continueFunc)
                            {
                                Console.WriteLine("1. Edit category of work");
                                Console.WriteLine("2. Edit experience");
                                Console.WriteLine("3. Edit desirable salary");
                                Console.WriteLine("4. Edit distance work");
                                Console.WriteLine("5. Edit carrer growth");
                                Console.WriteLine("6. Edit additional info");
                                Console.WriteLine("7. CANCEL");
                                Console.WriteLine("------------------");
                                bool chooseWhatToEditWhile = true;
                                while (chooseWhatToEditWhile)
                                {
                                    Console.Write("Input a number what to choose: ");
                                    string whatChange = Console.ReadLine();
                                    switch (whatChange)
                                    {
                                        case "1":{
                                                bool categoryWhile = true;
                                                while (categoryWhile)
                                                {
                                                    Console.WriteLine("Input a one category of work(write category not a number)(if you want cancel write CANCEL): ");
                                                    Console.WriteLine("1. IT");
                                                    Console.WriteLine("2. DESIGN");
                                                    Console.WriteLine("3. ACCOUNTING");
                                                    Console.WriteLine("4. MEDIA");
                                                    Console.WriteLine("5. SELLING");
                                                    categoryOfWork = Console.ReadLine();
                                                    switch (categoryOfWork)
                                                    {
                                                        case "IT":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoVacancy(1, vacancyCount - 1, categoryOfWork);
                                                            break;
                                                        case "DESIGN":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoVacancy(1, vacancyCount - 1, categoryOfWork);
                                                            break;
                                                        case "ACCOUNTING":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoVacancy(1, vacancyCount - 1, categoryOfWork);
                                                            break;
                                                        case "MEDIA":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoVacancy(1, vacancyCount - 1, categoryOfWork);
                                                            break;
                                                        case "SELLING":
                                                            chooseWhatToEditWhile = false;
                                                            categoryWhile = false;
                                                            Console.Clear();
                                                            Console.WriteLine("You edited category of work");
                                                            Console.WriteLine("------------------");
                                                            bllClass.editStringInfoVacancy(1, vacancyCount - 1, categoryOfWork);
                                                            break;
                                                        case "CANCEL":
                                                            Console.Clear();
                                                            Console.WriteLine("You canceled addinng.");
                                                            Console.WriteLine("------------------");
                                                            categoryWhile = false;
                                                            chooseWhatToEditWhile = false;
                                                            break;
                                                        default:
                                                            Console.WriteLine("------------------");
                                                            Console.WriteLine("Wrong command, try again.");
                                                            Console.WriteLine("------------------");
                                                            break;
                                                    }
                                                }
                                            } break;
                                        case "2":{
                                                bool contExper = true;
                                                bool experieWhile = true;
                                                while (experieWhile)
                                                {
                                                    Console.Write("Input a experience(if you want cancel adding write CANCEL): ");
                                                    string chooser = Console.ReadLine();
                                                    if (chooser != "CANCEL")
                                                    {
                                                        try
                                                        {
                                                            experience = Convert.ToInt32(chooser);
                                                            experieWhile = false;
                                                            chooseWhatToEditWhile = false;
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            new ExceptionInputNumberAreWrong(e.Message);
                                                            Console.WriteLine("Try again.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("You canceled.");
                                                        Console.WriteLine("------------------");
                                                        contExper = false;
                                                        experieWhile = false;
                                                        chooseWhatToEditWhile = false;
                                                    }
                                                }
                                                if (!contExper)
                                                {
                                                    break;
                                                }
                                                Console.Clear();
                                                Console.WriteLine("You edited experience");
                                                Console.WriteLine("------------------");
                                                bllClass.editIntInfoVacancy(1, vacancyCount - 1, experience);
                                            } break;
                                        case "3":{
                                                bool contSalary = true;
                                                bool salaryWhile = true;
                                                while (salaryWhile)
                                                {
                                                    Console.Write("Input a desirable salary(if you want cancel adding write CANCEL): ");
                                                    string chooser = Console.ReadLine();
                                                    if (chooser != "CANCEL")
                                                    {
                                                        try
                                                        {
                                                            desirableSalary = Convert.ToInt32(chooser);
                                                            salaryWhile = false;
                                                            chooseWhatToEditWhile = false;
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            new ExceptionInputNumberAreWrong(e.Message);
                                                            Console.WriteLine("Try again.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("You canceled.");
                                                        Console.WriteLine("------------------");
                                                        contSalary = false;
                                                        salaryWhile = false;
                                                        chooseWhatToEditWhile = false;
                                                    }
                                                }
                                                if (!contSalary)
                                                {
                                                    break;
                                                }
                                                Console.Clear();
                                                Console.WriteLine("You edited desirable salary");
                                                Console.WriteLine("------------------");
                                                bllClass.editIntInfoVacancy(2, vacancyCount - 1, desirableSalary);
                                            } break;
                                        case "4":{
                                                bool conDist = true;
                                                bool categoryWhileDist = true;
                                                while (categoryWhileDist)
                                                {
                                                    Console.WriteLine("Input if job have a distance work(if you want cancel write CANCEL): ");
                                                    Console.WriteLine("1. YES");
                                                    Console.WriteLine("2. NO");
                                                    Console.WriteLine("3. CANCEL");
                                                    categoryOfWork = Console.ReadLine();
                                                    switch (categoryOfWork)
                                                    {
                                                        case "YES":
                                                            isDistance = true;
                                                            categoryWhileDist = false;
                                                            bllClass.editBoolInfoVacancy(1, vacancyCount - 1, isDistance);
                                                            break;
                                                        case "NO":
                                                            isDistance = false;
                                                            categoryWhileDist = false;
                                                            bllClass.editBoolInfoVacancy(1, vacancyCount - 1, isDistance);
                                                            break;
                                                        case "CANCEL":
                                                            Console.Clear();
                                                            Console.WriteLine("You canceled addinng.");
                                                            Console.WriteLine("------------------");
                                                            categoryWhileDist = false;
                                                            conDist = false;
                                                            break;
                                                        default:
                                                            Console.WriteLine("------------------");
                                                            Console.WriteLine("Wrong command, try again.");
                                                            Console.WriteLine("------------------");
                                                            break;
                                                    }
                                                }
                                                if (!conDist)
                                                {
                                                    break;
                                                }
                                            } break;
                                        case "5":{
                                                bool conCar = true;
                                                bool categoryWhileCar = true;
                                                while (categoryWhileCar)
                                                {
                                                    Console.WriteLine("Input if job have a carrer growth(if you want cancel write CANCEL): ");
                                                    Console.WriteLine("1. YES");
                                                    Console.WriteLine("2. NO");
                                                    Console.WriteLine("3. CANCEL");
                                                    categoryOfWork = Console.ReadLine();
                                                    switch (categoryOfWork)
                                                    {
                                                        case "YES":
                                                            isCarrerGrowth = true;
                                                            categoryWhileCar = false;
                                                            bllClass.editBoolInfoVacancy(2, vacancyCount - 1, isCarrerGrowth);
                                                            break;
                                                        case "NO":
                                                            isCarrerGrowth = false;
                                                            categoryWhileCar = false;
                                                            bllClass.editBoolInfoVacancy(2, vacancyCount - 1, isCarrerGrowth);
                                                            break;
                                                        case "CANCEL":
                                                            Console.Clear();
                                                            Console.WriteLine("You canceled addinng.");
                                                            Console.WriteLine("------------------");
                                                            categoryWhileCar = false;
                                                            conCar = false;
                                                            break;
                                                        default:
                                                            Console.WriteLine("------------------");
                                                            Console.WriteLine("Wrong command, try again.");
                                                            Console.WriteLine("------------------");
                                                            break;
                                                    }
                                                }
                                                if (!conCar)
                                                {
                                                    break;
                                                }
                                            } break;
                                        case "6":{
                                                bool contExp = true;
                                                bool addWhile = true;
                                                while (addWhile)
                                                {
                                                    Console.Write("Input additional info(if you want cancel adding write CANCEL): ");
                                                    additionalInfo = Console.ReadLine();
                                                    if (additionalInfo != "CANCEL")
                                                    {
                                                        addWhile = false;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("You canceled addinng.");
                                                        Console.WriteLine("------------------");
                                                        addWhile = false;
                                                        contExp = false;
                                                    }
                                                }
                                                if (!contExp)
                                                {
                                                    break;
                                                }
                                                Console.Clear();
                                                Console.WriteLine("You edited additional info");
                                                Console.WriteLine("------------------");
                                                bllClass.editStringInfoVacancy(2, vacancyCount - 1, additionalInfo);
                                            } break;
                                        case "7":
                                            Console.Clear();
                                            chooseWhatToEditWhile = false;
                                            continueFunc = false;
                                            break;
                                        default:
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("Wrong command, try again.");
                                            Console.WriteLine("------------------");
                                            break;
                                    }
                                }
                            }
                        } break;
                    case "DeleteVacancy":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfVacancy = bllClass.getCountOfVacancy();
                            if (numberOfVacancy != 0)
                            {
                                for (int i = 0; i < numberOfVacancy; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {bllClass.getShortInfoVacancy(i)}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any vacancy in list.");
                                Console.WriteLine("------------------");
                                break;
                            }
                            bool chooseVacancyDeleteWhile = true;
                            int chooseVacancyToDelete = 0;
                            while (chooseVacancyDeleteWhile)
                            {
                                bool next = true;
                                Console.Write("Input a number(if you want cancel write CANCEL): ");
                                string chooser = Console.ReadLine();
                                if (chooser != "CANCEL")
                                {
                                    try
                                    {
                                        chooseVacancyToDelete = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        new ExceptionInputNumberAreWrong(e.Message);
                                        Console.WriteLine("Try again.");
                                        next = false;
                                    }
                                    if (next)
                                    {
                                        if (chooseVacancyToDelete <= 0 || chooseVacancyToDelete > numberOfVacancy)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            bllClass.deleteVacancy(chooseVacancyToDelete - 1);
                                            Console.WriteLine("You deleted vacancy from list.");
                                            Console.WriteLine("------------------");
                                            chooseVacancyDeleteWhile = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled.");
                                    Console.WriteLine("------------------");
                                    chooseVacancyDeleteWhile = false;
                                }
                            }
                        } break;
                    case "SortByCategory":{
                            Console.Clear();
                            bool con1 = true;
                            bool categoryWhile1 = true;
                            numberOfVacancy = bllClass.getCountOfVacancy();
                            while (categoryWhile1)
                            {
                                Console.WriteLine("Input a one category of work(if you want cancel write CANCEL): ");
                                Console.WriteLine("1. IT");
                                Console.WriteLine("2. DESIGN");
                                Console.WriteLine("3. ACCOUNTING");
                                Console.WriteLine("4. MEDIA");
                                Console.WriteLine("5. SELLING");
                                categoryOfWork = Console.ReadLine();
                                switch (categoryOfWork)
                                {
                                    case "IT":
                                        categoryWhile1 = false;
                                        break;
                                    case "DESIGN":
                                        categoryWhile1 = false;
                                        break;
                                    case "ACCOUNTING":
                                        categoryWhile1 = false;
                                        break;
                                    case "MEDIA":
                                        categoryWhile1 = false;
                                        break;
                                    case "SELLING":
                                        categoryWhile1 = false;
                                        break;
                                    case "CANCEL":
                                        Console.Clear();
                                        Console.WriteLine("You canceled addinng.");
                                        Console.WriteLine("------------------");
                                        categoryWhile1 = false;
                                        con1 = false;
                                        break;
                                    default:
                                        Console.WriteLine("------------------");
                                        Console.WriteLine("Wrong command, try again.");
                                        Console.WriteLine("------------------");
                                        break;
                                }
                            }
                            if (!con1)
                            {
                                break;
                            }
                            Console.Clear();
                            int count = 1;
                            bool nothing = true;
                            for (int i = 0; i < numberOfVacancy; i++)
                            {
                                if (bllClass.getCategoryOfWorkVacancy(i) == categoryOfWork)
                                {
                                    nothing = false;
                                    Console.WriteLine($"{count}. {bllClass.getShortInfoVacancy(i)}");
                                    count++;
                                }
                            }
                            if (nothing)
                            {
                                Console.Clear();
                                Console.WriteLine("You dont have any vacancy in this category");
                            }
                            Console.WriteLine("------------------");
                        } break;
                    case "EndWork":
                        Console.Clear();
                        whileMain = false;
                        break;
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong command, try again.");
                        Console.WriteLine("------------------");
                        break;
                }
            }
        }
    }
}
