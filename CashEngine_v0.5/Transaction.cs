using System;

namespace CashEngine.Wallet
{
    /// <summary>
    /// Describes a money movement inside the CashEngine.
    /// Every balance modification MUST generate one Transaction.
    /// </summary>
    [Serializable]
    public sealed class Transaction
    {
        /// <summary>
        /// Unique transaction identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// UTC timestamp.
        /// </summary>
        public DateTime TimestampUtc { get; }

        /// <summary>
        /// Currency involved.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// Positive amount.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Current balance AFTER this transaction.
        /// </summary>
        public decimal BalanceAfter { get; }

        /// <summary>
        /// Why the transaction happened.
        /// Example:
        /// IdleIncome
        /// DailyReward
        /// ShopPurchase
        /// OfflineReward
        /// MissionReward
        /// </summary>
        public string Reason { get; }

        /// <summary>
        /// Money added or removed.
        /// </summary>
        public TransactionType Type { get; }

        /// <summary>
        /// Optional metadata.
        /// Future:
        /// SkinId
        /// MissionId
        /// ItemId
        /// AdPlacement
        /// etc.
        /// </summary>
        public string Metadata { get; }

        public bool IsIncome => Type == TransactionType.Income;

        public bool IsExpense => Type == TransactionType.Expense;

        public Transaction(
            Currency currency,
            decimal amount,
            decimal balanceAfter,
            TransactionType type,
            string reason,
            string metadata = "")
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));

            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Id = Guid.NewGuid();

            TimestampUtc = DateTime.UtcNow;

            Currency = currency;

            Amount = decimal.Round(amount, currency.Precision);

            BalanceAfter = decimal.Round(balanceAfter, currency.Precision);

            Type = type;

            Reason = reason ?? string.Empty;

            Metadata = metadata ?? string.Empty;
        }

        public override string ToString()
        {
            string sign = IsIncome ? "+" : "-";

            return
                $"{TimestampUtc:u} | " +
                $"{sign}{Amount} {Currency.Symbol} | " +
                $"{Reason}";
        }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}
