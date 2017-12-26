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
    ///- there is something bad, there are many branches in "withdraw" method, that the code that test this funtion is explicit
    ///- why it bad? explicit condition test making the execution of our code complicated
    ///- Advice:
    ///     - donot keep money as decimal.
    ///     - introduce special "money" class to keep "amount" and "currency" together
    ///     
    ///  How Many ways to excute the "deposit" method?
    ///  you have 2 ways : 1- either "IsClosed" is satisfied 2- or not satisfied
    ///  so we need 2 test cases to test "deposit" method
    ///  
    /// How Many Test cases needed for "Withdraw" method?
    /// you have 3 test cases
    /// 
    /// Customer Requirement 3:
    /// - Account should be frozen if not used for some time.
    /// - Account will be unfrozen automatically on deposit or withdraw
    /// - Unfreezing the account triggers a custom action
    /// 
    /// - you know began to feel that the class become more complex
    /// - now "deposit" function need more tests:
    ///     - deposit invoked on frozen account
    ///     - check that account is unfrozen after depositing
    ///     - call back function is not called if account is unforzen
    ///     
    /// - now "withdraw" function need more tests:
    ///     - deposit invoked on frozen account
    ///     - check that account is unfrozen after depositing
    ///     - call back function is not called if account is unforzen
    ///     - ...
    ///     
    /// - ADVICE:
    ///     - Start worrying as soon as number of unit tests has started to double with every new feature added.
    ///     - this problem can be solved using "State" design pattern
    /// 
    ///  Modification 1:
    /// - to simply my class firstly i implement a method called "ManageUnfreezing", and move logic to it
    /// - we introduced "else" branch in this method that "Do Nothing", but why we do this?
    /// - we do this to make the implementation symmetric
    /// 
    ///   Modification 2:
    /// - there another better option for making implementation symmetric is to introduce "Guard Clause"
    /// - the code after the "Guard Clause" is executed unconditionally    
    /// ADVICE:
    ///     - avoid incomplete "if-then" instructions without "else" or use "guard clause"
    /// 
    /// Modification 3:    
    /// - after creating new method "ManageUnfreezing", and add its logic to it, i will make further change on this method
    /// - inside it i will implement 2 additionally methods "UnFreeze()", and "StayUnfrozen()"
    /// 
    /// Modification 4:
    /// convert the created method "ManageUnfreezing" into a delegate
    /// 
    /// Modification 5:
    /// - initially the account is unfrozen
    /// - the target of this solution, instead of using boolean flag to decide the status (free or unFreeze) we used delegate that points to the status
    /// 
    /// the next step is to move the all manage freeze to new class
    /// </summary>
    class Account
    {
        public decimal Balance { get; private set; }
        private bool isVerified { get; set; }

        // Customer Requirement 2:
        private bool IsClosed { get; set; }

        // Customer Requirement 3
        // Modification 5:
        // private bool IsFrozen { get; set; }
        private Action OnUnFreeze { get; }

        public Account(Action onUnfreeze)
        {
            this.OnUnFreeze = onUnfreeze;

            //this.ManageUnfreezing = () =>
            //{
            //    if (this.IsFrozen)
            //    {

            //    }
            //    else
            //    {
            //        this.StayUnfrozen();
            //    }
            //};


            // Modification 5:
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        public void Deposit(decimal amount)
        {
            // Customer Requirement 2:
            if (this.IsClosed)
                return; // Or do something else...

            //// Customer Requirement 3
            //if (this.IsFrozen)
            //{
            //    this.IsFrozen = false;
            //    this.OnUnFreeze();
            //}

            this.ManageUnfreezing();

            // Deposit Money
            this.Balance += amount;
        }

        // Modification 4:
        private Action ManageUnfreezing { get; set; }

        //private void ManageUnfreezing()
        //{
        //    // Modification 1:

        //    //// Customer Requirement 3
        //    //if (this.IsFrozen)
        //    //{
        //    //    this.IsFrozen = false;
        //    //    this.OnUnFreeze();
        //    //}

        //    //// -we introduced "else" branch in this method
        //    //else
        //    //{
        //    //    // Do Nothing
        //    //}

        //    // Modification 2:
        //    //if (!this.IsFrozen) // another option to introduce "Guard Clause"
        //    //    return;

        //    //this.IsFrozen = false;
        //    //this.OnUnFreeze();


        //    // Modification 3:
        //    if(this.IsFrozen)
        //    {
        //        this.Unfreeze();
        //    }
        //    else
        //    {
        //        this.StayUnfrozen();
        //    }
        //}

        // Modification 3:
        private void Unfreeze()
        {
            // Modification 5:
            // this.IsFrozen = false;
            this.OnUnFreeze();

            // Modification 5
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        // Modification 3:
        private void StayUnfrozen()
        {

        }

        public void Withdraw(decimal amount)
        {
            if (!this.isVerified)
                return; // or do something else

            // Customer Requirement 2:
            if (!this.IsClosed)
                return; // or do something else

            //// Customer Requirement 3
            //if (this.IsFrozen)
            //{
            //    this.IsFrozen = false;
            //    this.OnUnFreeze();
            //}
            this.ManageUnfreezing();

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

        // Customer Requirement 3
        public void Freeze()
        {
            if (this.IsClosed)
                return; // Account must not be closed
            if (this.isVerified)
                return; // Account must be verified

            // Modification 5:
            //this.IsFrozen = true;

            // Modification 5
            this.ManageUnfreezing = this.Unfreeze;
        }
    }
}
