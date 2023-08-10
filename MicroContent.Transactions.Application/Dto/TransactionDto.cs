namespace MicroContent.Transactions.Application.Dto;

public class TransactionDto
{
    public int TransactionId { get; set; }
    public string AdressFrom { get; set; }
    public string AdressTo { get; set; }
    public string LocationByIp { get; set; }
    public bool IsFirstAdressTransaction { get; set; }
}

