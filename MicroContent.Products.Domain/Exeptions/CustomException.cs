namespace MicroContent.Transactions.Domain.Exeptions;

public abstract class CustomException : Exception
{
    protected CustomException(string message) : base(message)
    {
    }
}

