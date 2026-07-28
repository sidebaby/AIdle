public sealed class Wallet
{
    public Currency Currency { get; }

    public decimal Balance { get; }

    public IReadOnlyList<Transaction> Transactions { get; }

    public event Action<decimal> BalanceChanged;

    public event Action<Transaction> TransactionAdded;

    public bool CanSpend(decimal amount);

    public Transaction Add(
        decimal amount,
        string reason,
        string metadata = "");

    public Transaction Spend(
        decimal amount,
        string reason,
        string metadata = "");

    public void ClearHistory();

    public decimal TotalIncome();

    public decimal TotalExpense();

    public Transaction LastTransaction();

    public IReadOnlyList<Transaction> History();
}
