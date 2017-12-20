using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreOO
{
    /// <summary>
    /// Customer Requirement 1:
    ///     - Money can be deposited at any time
    ///     - Money can be withdrawn "Only After" the account owner's identity has been verified
    ///- using "If" instruction in fresh code is not good, look at below additonal requirement
    /// 
    /// Customer Requirement 2:
    ///     - account holder can close the account at any time
    ///     - Closed account does not allow deposit and withdraw
    ///     
    ///- there is something branch, there are many branches in "withdraw" method, that the code that test this funtion is explicit
    ///- why it bad? explicit condition test making the execution of our code complicated
    ///- Advice:
    ///     - donot keep money as decimal.
    ///     - introduce special "money" class to keep "amount" and "currency" together
    /// </summary>
    class Account
    {
        public decimal Balance { get; private set; }
        private bool isVerified { get; set; }

        // Customer Requirement 2:
        private bool IsClosed { get; set; }
        public void Deposit(decimal amount)
        {
            // Customer Requirement 2:
            if (this.IsClosed)
                return; // Or do something else..
            // Deposit Money
        }

        public void Withdraw(decimal amount)
        {
            if (!this.isVerified)
                return; // or do something else

            // Customer Requirement 2:
            if (!this.IsClosed)
                return; // or do something else

            this.Balance -= amount;
        }

        public void HolderVerified()
        {
            this.isVerified = true;
        }

        // Customer Requirement 2:
        public void Close()
        {
            this.IsClosed = true;
        }
    }
}
