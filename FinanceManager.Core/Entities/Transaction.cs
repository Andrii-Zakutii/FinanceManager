using FinanceManager.Core.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Core.Entities
{
    public class Transaction : Entity
    {
        private Category _category;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Sum { get; set; }

        [Required]
        public TransactionTypes? Type { get; set; }

        [Required]
        public DateTime? Time { get; set; }

        public string Description { get; set; }

        public Category Category
        {
            get => _category;
            set
            {
                if (IsCompatible(value) == false)
                    throw new ArgumentException();

                _category = value;
            }
        }

        [Required]
        public long MoneyAccountId { get; set; }

        public MoneyAccount MoneyAccount { get; set; }

        #region Statistics
        public bool BelongsTo(User user) => MoneyAccount.BelongsTo(user);

        public bool BelongsTo(MoneyAccount account) => MoneyAccountId == account?.Id;

        public bool IsExpense() => Type == TransactionTypes.Expense;

        public bool IsIncome() => Type == TransactionTypes.Income;

        public decimal GetShareWithinAccount(TimeRange range)
        {
            decimal sum = MoneyAccount.GetTransactionSum(TransactionTypes.Expense, range);
            return Sum.Value / sum;
        }

        public decimal GetShare(TimeRange range)
        {
            var user = MoneyAccount.User;
            decimal sum = user.GetTransactionSum(TransactionTypes.Expense, range);
            return Sum.Value / sum;
        }

        private bool IsCompatible(Category category) =>
            category.Type == CategoryTypes.ExpenseCategory && Type == TransactionTypes.Expense ||
            category.Type == CategoryTypes.IncomeCategory && Type == TransactionTypes.Income;
        #endregion
    }
}
