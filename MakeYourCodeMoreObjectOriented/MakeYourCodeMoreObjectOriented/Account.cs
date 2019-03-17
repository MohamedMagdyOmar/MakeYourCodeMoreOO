using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented
{
    // Note: Start worrying as soon as number of unit tests has started tpo double with every new feature added
    // Note: with every new requirement we added new branching logic, which is something not good
    // Note: Requirment 1 (IsVerified) -> branching logic
    // Note: Requirment 2 (IsClosed) -> to satisfy this requirement, new branching logic is added
    // Note: Requirment 3 (IsFrozen) -> to satisfy this requirement, new branching logic is added

    // Note: we need a technique to put previous problem (add new branching logic for every new requirement) under control
    // Note: the solution of this problem will depend on "State Design Pattern"
    class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }

        // we need to add requirement that when UnFreezing the Account, triggers a custom action (calls callback function)
        private Action OnUnfreeze { get; }

        // this deposit method has 2 ways of execution
        // #1: Deposit 10, Close, Deposit 1 - Balance == 10 (IsClosed executed, and exit in if condition)
        // #2: Deposit 10, Deposit 1, Balance == 11 (increase balance by amount)
        // so we have 2 unit test cases

        // #6: Deposit 10, Freeze, Deposit 1 - onUnfreeze was called
        // #7: Deposit 10, Freeze, Deposit 1 - isFrozen == false
        // #8: Deposit 10, Deposit 1 - OnUnfreeze was not called
        // 3 additional unit test cases is needed when we added unFrozen Requirement
        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;

            if(this.IsFrozen)
            {
                this.IsFrozen = false;

                // custom action for unfreezing the acount
                this.OnUnfreeze();
            }
            this.Balance += amount;
        }

        // this Withdraw method has following test cases:
        // #3: Deposit 10, withdraw 1 - Balance == 10
        // #4: Deposit 10, Verify, Close, withdraw 1 Balance == 10
        // #5: Deposit 10, Verify, withdraw 1 - Balance == 9
        // so we have 3 unit test cases

        // #9: Deposit 10, Verify, Freeze, Withdraw 1 - onUnfreeze was called
        // #10: Deposit 10, Verify, Freeze, Withdraw 1 - isFrozen == false
        // #11: Deposit 10, Verify, Withdraw 1 - OnUnfreeze was not called

        // tests 9, 10, 11 was added because of Unfreeze Requirement is added
        // note that test 9, 10, 11, is similar to test 6, 7, 8, so we have repeated 
        // same tests again (not reuse old test cases)
        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return;

            if (this.IsClosed)
                return;

            if (this.IsFrozen)
            {
                this.IsFrozen = false;

                // custom action for unfreezing the acount
                this.OnUnfreeze();
            }

            this.Balance -= amount;
            // Withdraw Money
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.IsFrozen = true;
        }
    }
}
