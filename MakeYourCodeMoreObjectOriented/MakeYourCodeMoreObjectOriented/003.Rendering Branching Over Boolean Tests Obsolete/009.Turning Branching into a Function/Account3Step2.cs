using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._009.Turning_Branching_into_a_Function
{
    class Account3Step2
    {
        // Target:
        // Turning Branching Into Function. How?
        // remove boolean flag and if conditions that depend on it, and replace it with 2 methods, and a delegate.
        // One Method Handle Freezing, and One Method Handle UnFreezing
        // Delegate can be assigned any of these 2 methods based on its current state, if we are in constructor(create new instance) -> then ManageUnfreezing state is StayUnfrozen
        // https://refactoring.guru/replace-conditional-with-polymorphism
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }


        private Action ManageUnfreezing { get; set; }

        public Account3Step2(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;

            // in step 1 it was a method, here we converted to Delegate, and Invoked in the constructor.
            // but since when you create an instance of this object, it supposed you are going to withdraw or deposit. so it make sense to change the 
            // code as below.

            //this.ManageUnfreezing = () =>
            //{
            //    if (this.IsFrozen)
            //    {
            //        this.Unfreeze();
            //    }

            //    else
            //    {
            //        this.StayUnfrozen();
            //    }
            //};

            // initially it is unfrozen
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;

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

            // Not Required any more
            //this.IsFrozen = true;

            // below code is added, because if the account is frozen, and
            // you need to unfreeze, you can do that by calling this function "ManageUnfreezing"
            this.ManageUnfreezing = this.Unfreeze;
        }

        private void Unfreeze()
        {
            // Not Required any more
            //this.IsFrozen = false;

            this.OnUnfreeze();

            // after Unfreezing account, there is no reason to repeat it again so
            // the new state of "ManageUnfreeze" property to 
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        private void StayUnfrozen()
        {

        }
    }
}

