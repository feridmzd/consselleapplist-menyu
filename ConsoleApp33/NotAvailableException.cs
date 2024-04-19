using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    public class NotAvailableException:Exception
    {
        NotAvailableException(string message):base(message) { }

    }
}
