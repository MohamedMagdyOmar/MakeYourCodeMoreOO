using MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._010.Turning_Function_into_a_State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._011.Moving_All_State_related_Code_into_States
{
    class Account5
    {
        // Target:
        // previously we have moved all Freeze State responsibility from account class to IFreezable Interface.
        // Now we are going to make same changes but For "IsVerified", and "IsClosed".

        // Conclusion:
        // this class now is dealing only with balance.
        // the class now is doing only one thing (SRP).
        // SO WHAT WE DONE IS MOVING BRANCHING LOGIC TO EXPLICIT STATE, AND MOVE THESE STATES TO SEPERATE CLASS.

        // One new requirement means one new class will be added.
        // New requirement does not require an existing class to change.
        public decimal Balance { get; private set; }
        //private bool IsVerified { get; set; }
        //private bool IsClosed { get; set; }
        //private bool IsFrozen { get; set; }

        //private IFreezable Freezable { get; set; }
        private IAccountState State { get; set; }

        public Account5(Action onUnfreeze)
        {
            // initial state is not verified
            this.State = new NotVerified(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            //if (this.IsClosed)
            //    return;
            //this.Freezable = this.Freezable.Deposit();

            this.State = this.State.Deposit(() => { this.Balance += amount; });
            
        }

        public void Withdraw(decimal amount)
        {
            //if (!this.IsVerified)
            //    return;

            //if (this.IsClosed)
            //    return;

            //this.Freezable = this.Freezable.Withdraw();
            this.State = this.State.Withdraw(() => { this.Balance -= amount; });
        }

        public void HolderVerified()
        {
            //this.IsVerified = true;
            this.State = this.State.HolderVerified();
        }

        public void Close()
        {
            //this.IsClosed = true;
            this.State = this.State.Close();
        }

        public void Freeze()
        {
            //if (this.IsClosed)
            //    return;
            //if (!this.IsVerified)
            //    return;

            //this.Freezable = this.Freezable.Freeze();
            this.State = this.State.Freeze();
        }
    }
}
