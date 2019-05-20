using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented
{
    // Target Of Video:
    // give a sample of Bad code, that whenever new requirement is added, more boolean flags (IsVerified, IsClosed), and so more if conditions are required 
    // (check Req2, and Req4) which makes your code not good, and not OO.

    // Requirements:
    // Requirement 1: Money Can Be deposited at any time
    // Requirement 2: Money can be withdrawn only after the account owner's identity has been verified
    // Requirement 3: Account Holder can close the account at any time
    // Requirement 4: Closed account does not allow deposit and withdraw

    // Consequences:
    // Requirement 2, 4: Boolean Flags add (IsVerified, IsClosed)
    // code that test account state (if (!this.IsVerified)) and (if (this.IsClosed)) is explicit condition which is bad thing.
    // but why explicit condition test is bad? Bceause it make code execution complicated
    class Account1
    {
        public decimal Balance { get; private set; }

        // To Satisfy Requirement 2
        private bool IsVerified { get; set; }

        // To Satisfy Requirement 4
        private bool IsClosed { get; set; }

        public void Deposit(decimal amount)
        {
            // To Satisfy Requirement 4
            if (this.IsClosed)
                return;

            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            // To Satisfy Requirement 2
            if (!this.IsVerified)
                return;

            // To Satisfy Requirement 4
            if (this.IsClosed)
                return;

            // Withdraw Money
            this.Balance -= amount;
            
        }

        // To Satisfy Requirement 4
        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        // To Satisfy Requirement 4
        public void Close()
        {
            this.IsClosed = true;
        }
    }
}
