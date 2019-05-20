using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented
{
    // Target Of Video:
    // explain for you why previous code is bad. it is bad because we have multiple
    // if conditions, this makes each method has different branches(different way of excution of a method)
    // check "Deposit" method you will have 2 ways of excution, and so 2 test cases required.
    // check "Withdraw" method, you will have 3 ways of execution, and so 3 test cases are required (total 5 now).
    // and when we add new requirement (Freeze/UnFreeze), that doubles number of test cases on each of the previous method.

    // New Requirements:
    // Requirement 1: Account should be frozen if not used for some time.
    // Requirement 2: Account will be unfrozen automatically on deposit or withdraw, Unfreezing the account triggers a custom action (callback)

    // Notes:
    // Note-1: Start worrying as soon as number of unit tests has started tpo double with every new feature added
    // Note-2: with every new requirement we added new branching logic, which is something not good
    // Note-3: we need a technique to put previous problem (add new branching logic for every new requirement) under control
    // Note-4: the solution of this problem will depend on "State Design Pattern"

    class Account2
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        // To Satisfy Requirement 1
        private bool IsFrozen { get; set; }

        // To Satisfy Requirement 2
        private Action OnUnfreeze { get; }

        // To Satisfy Requirement 2 (custom callback function)
        public Account2(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        // this deposit method has 2 ways of execution
        // #1: Deposit 10, Close, Deposit 1 - Balance == 10 (IsClosed executed, and exit in if condition)
        // #2: Deposit 10, Deposit 1, Balance == 11 (increase balance by amount)
        // so we have 2 unit test cases

        // #6: Deposit 10, Freeze, Deposit 1 - onUnfreeze was called
        // #7: Deposit 10, Freeze, Deposit 1 - isFrozen == false
        // #8: Deposit 10, Deposit 1 - OnUnfreeze was not called
        // 3 additional unit test cases is needed when we added Requirement 1, 2
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;

            // To Satisfy Requirement 1, 2, new branching logic is added
            if (this.IsFrozen)
            {
                this.IsFrozen = false;

                // To Satisfy Requirement 2
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

            // To Satisfy Requirement 1, 2, new branching logic is added
            if (this.IsFrozen)
            {
                this.IsFrozen = false;

                // To Satisfy Requirement 2
                this.OnUnfreeze();
            }

            this.Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        // To Satisfy Requirement 1
        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.IsFrozen = true;
        }
    } }

