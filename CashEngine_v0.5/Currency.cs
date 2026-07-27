using System;

namespace CashEngine.Wallet
{
    /// <summary>
    /// Represents a currency used by the CashEngine wallet.
    /// Immutable value object.
    /// </summary>
    [Serializable]
    public sealed class Currency : IEquatable<Currency>
    {
        /// <summary>
        /// Internal identifier (e.g. GOLD, GEM).
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Display name shown to the player.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Currency symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Number of decimal digits.
        /// </summary>
        public int Precision { get; }

        public Currency(
            string id,
            string displayName,
            string symbol,
            int precision = 0)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException(nameof(displayName));

            if (precision < 0)
                throw new ArgumentOutOfRangeException(nameof(precision));

            Id = id.Trim();
            DisplayName = displayName.Trim();
            Symbol = symbol ?? string.Empty;
            Precision = precision;
        }

        public override string ToString()
        {
            return $"{DisplayName} ({Symbol})";
        }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(
                Id,
                other.Id,
                StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Currency);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Id);
        }

        public static bool operator ==(Currency left, Currency right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Currency left, Currency right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Default soft currency.
        /// </summary>
        public static readonly Currency Coins =
            new Currency(
                "COINS",
                "Coins",
                "$",
                0);

        /// <summary>
        /// Default premium currency.
        /// </summary>
        public static readonly Currency Gems =
            new Currency(
                "GEMS",
                "Gems",
                "♦",
                0);
    }
}
