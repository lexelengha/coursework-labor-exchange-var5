using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_PL_
{
    public class ExceptionInputNumberAreWrong : SystemException
    {
        public ExceptionInputNumberAreWrong(string exception)
        {
            Console.WriteLine("------------------");
            Console.WriteLine(exception);
            Console.WriteLine("------------------");
        }
    }
}
