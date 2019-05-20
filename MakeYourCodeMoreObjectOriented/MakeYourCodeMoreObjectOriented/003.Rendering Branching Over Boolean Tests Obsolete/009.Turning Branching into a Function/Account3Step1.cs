using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented
{
    // Target Of Video:
    // is to remove the complexity (branching due to many If conditions).
    // we have 3 branching conditions (!this.IsVerified), (this.IsClosed), and (this.IsFrozen). we will refactor our code
    // to get rid of our first Branching Conditions "(this.IsFrozen)".


    
    // we replace the code if (this.IsFrozen) and create new function for it "ManageUnfreeze" to prevent repition of 
    // this code in "Deposit" and "Withdraw" Method. and also split this method into 2 methods "Unfreeze()" and "StayUnfrozen"

    class Account3Step1
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }

        public Account3Step1(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;

            // Step 4: but this can be a delegate insetad of method
            this.ManageUnfreezing();

            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return;

            if (this.IsClosed)
                return;

            
            this.ManageUnfreezing();

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

        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.IsFrozen = true;
        }

        // Step 1, Move If Condition "if (this.IsFrozen)" to a seperate Method, and remove it from "Deposit" and "Withdraw" methods. 
        private void ManageUnfreezing()
        {
            if (this.IsFrozen)
            {
                // Step 2, Move Unfreeze Logic to seperate Method
                this.Unfreeze();
            }

            else
            {
                // step 3, create function for StayUnfrozen may be used later.
                this.StayUnfrozen();
            }
        }

        private void Unfreeze()
        {
            this.IsFrozen = false;

            this.OnUnfreeze();
        }

        private void StayUnfrozen()
        {

        }
    }
}

