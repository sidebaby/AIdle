public sealed class Wallet
{
    public Currency Currency { get; }

    public decimal Balance { get; private set; }

    public IReadOnlyList<Transaction> History { get; }

    public int TransactionCount { get; }

    public event Action<decimal> BalanceChanged;

    public event Action<Transaction> TransactionAdded;

    public Wallet(Currency currency);

    public bool CanSpend(decimal amount);

    public Transaction Add(
        decimal amount,
        string reason,
        string metadata = "");

    public bool TrySpend(
        decimal amount,
        string reason,
        out Transaction transaction,
        string metadata = "");

    public Transaction Spend(
        decimal amount,
        string reason,
        string metadata = "");

    public void ClearHistory();

    public decimal TotalIncome();

    public decimal TotalExpense();

    public decimal LifetimeIncome();

    public decimal LifetimeExpense();

    public Transaction LastTransaction();

    public void Reset();
}
