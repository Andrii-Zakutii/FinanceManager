using FinanceManager.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager.Infrastructure
{
    class SeedData
    {
        private const string _userEmail = "user@example.com";
        private const string _userPasssword = "Secret123$";

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                User user = userManager.FindByEmailAsync(_userEmail).Result;

                if (user == null)
                {
                    user = new User { Email = _userEmail, UserName = _userEmail };

                    var categories = new List<Category>
                    {
                        new Category
                        {
                            Name = "Sport",
                            Type = TransactionTypes.Expense,
                            User = user,
                        },

                        new Category
                        {
                            Name = "Food",
                            Type = TransactionTypes.Expense,
                            User = user,
                        },

                        new Category
                        {
                            Name = "Work",
                            Type = TransactionTypes.Income,
                            User = user,
                        },
                    };

                    user.Accounts = new List<MoneyAccount>
                    {
                        new MoneyAccount
                        {
                            Name = "Personal",
                            InitialSum = 100000,
                            Transactions = new List<Transaction>
                            {
                                new Transaction
                                {
                                    Sum = 100,
                                    Time = DateTime.Now,
                                    Type = TransactionTypes.Expense,
                                    Category = categories.Where(c => c.Name == "Sport").First(),
                                },

                                new Transaction
                                {
                                    Sum = 200,
                                    Time = DateTime.Now,
                                    Type = TransactionTypes.Expense,
                                    Category = categories.Where(c => c.Name == "Food").First(),
                                },

                                new Transaction
                                {
                                    Sum = 300,
                                    Time = DateTime.Now,
                                    Type = TransactionTypes.Income,
                                    Category = categories.Where(c => c.Name == "Work").First(),
                                },
                            }
                        },

                        new MoneyAccount
                        {
                            Name = "Family",
                            InitialSum = 20000,
                            Transactions = new List<Transaction>
                            {
                                new Transaction
                                {
                                    Sum = 10,
                                    Time = DateTime.Now,
                                    Type = TransactionTypes.Expense,
                                    Category = categories.Where(c => c.Name == "Food").First(),
                                },

                                new Transaction
                                {
                                    Sum = 20,
                                    Time = DateTime.Now,
                                    Type = TransactionTypes.Expense,
                                    Category = categories.Where(c => c.Name == "Food").First(),
                                },

                                new Transaction
                                {
                                    Sum = 100,
                                    Time = DateTime.Now,
                                    Type = TransactionTypes.Income,
                                    Category = categories.Where(c => c.Name == "Work").First(),
                                },
                            }
                        },
                    };

                    var _ = userManager.CreateAsync(user, _userPasssword).Result;
                }
            }
        }
    }
}
