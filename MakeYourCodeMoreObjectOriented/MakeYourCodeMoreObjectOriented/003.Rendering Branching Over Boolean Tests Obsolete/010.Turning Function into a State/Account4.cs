using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._010.Turning_Function_into_a_State
{
    class Account4
    {
        // Target:
        // Currently the "Account" Class has "ManageUnfreezing" Action, that is responsible for
        // HOW and WHEN to change the state from Frozen To UnFrozen and vice versa.
        // the problem now that changing the state becomes "Account" class responsibility, which is not correct (SRP).
        // (the "Account" class has to think when and how to change the state)

        // Conclusion:
        // we have made 2 major improvments as a consequences of "State Pattern".
        // 1- Class does not have to represent its state explicity anymore (logic of freezing and unfreezing is wrapped inside another class).
        // 2- Class doesnot have to manage state transition logic.
        
        // How:
        // Your Target Now is to move the responsibility of changing the state from Frozn to Unfrozen (How, and When) from "Account" Class
        // So we will create an interface, whose responsibility to decide How and When freezing state should be changed (IFreezable)
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        private bool IsFrozen { get; set; }

        // Account class will not be responsible for it any more.
        //private Action OnUnfreeze { get; }

        // added because we will delegate chaning the state to this element
        private IFreezable Freezable { get; set; }

        // we do not need it anymore, because changing the state become the interface responsibility
        // private Action ManageUnfreezing { get; set; }

        public Account4(Action onUnfreeze)
        {
            // Account class will not be responsible for it any more.
            //this.OnUnfreeze = onUnfreeze;

            // we do not need it anymore, because changing the state become the interface responsibility
            // this.ManageUnfreezing = this.StayUnfrozen;
            this.Freezable = new Active(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;

            // we do not need it anymore, because changing the state become the interface responsibility
            //this.ManageUnfreezing();

            // state change is now operated by Freezable.Deposit()
            // it will change the state and return the result for us.
            this.Freezable = this.Freezable.Deposit();

            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return;

            if (this.IsClosed)
                return;

            // we do not need it anymore, because changing the state become the interface responsibility
            //this.ManageUnfreezing();

            // state change is now operated by Freezable.Withdraw()
            // it will change the state and return the result for us.
            this.Freezable = this.Freezable.Withdraw();

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

            // we do not need it anymore, because changing the state become the interface responsibility
            //this.ManageUnfreezing = this.Unfreeze;

            this.Freezable = this.Freezable.Freeze();
        }

        // we do not need it anymore, because changing the state become the interface responsibility
        //private void Unfreeze()
        //{
        //    this.OnUnfreeze();

        //    this.ManageUnfreezing = this.StayUnfrozen;
        //}

        //private void StayUnfrozen()
        //{

        //}
    }
}
