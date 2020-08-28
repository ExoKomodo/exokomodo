using System;
namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Helpers
{
    public class Bank
    {
        #region Public

        #region Constructors
        public Bank(decimal balance = 0m)
        {
            Balance = balance;
        }
        #endregion

        #region Members
        public decimal Balance { get; private set; }
        #endregion

        #region Member Methods
        public void Deposit(decimal deposit)
        {
            Balance += deposit;
        }

        public bool Withdraw(decimal withdrawal, bool force = false)
        {
            if (!force && Balance < withdrawal)
            {
                return false;
            }
            Balance -= withdrawal;
            return true;
        }
        #endregion

        #endregion
    }
}
