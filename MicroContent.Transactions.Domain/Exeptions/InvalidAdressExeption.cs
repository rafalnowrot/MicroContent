using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MicroContent.Transactions.Domain.Exeptions;

public sealed class InvalidAdressExeption : CustomException
{
    public string Adress { get; }

    public InvalidAdressExeption(string adress) : base($"This adress is not valid: {adress}.")
    {
        Adress = adress;
    }
}

