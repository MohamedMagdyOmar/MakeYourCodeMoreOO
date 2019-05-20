using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._010.Turning_Function_into_a_State
{
    // the purpose of this interface is to think How and When state of freezing an account should be changed.
    
    // we have some methods/Actions that care about (affecting on) changing the state which are:
    // Deposit, Withdraw, and Freeze.

    // we have created 2 classes that defines these 2 states (Active, Frozen)
    // State Pattern: Object of the state class represents one state. change the object when you want to
    // change the state.
    interface IFreezable
    {
        // it return IFreezable (next state)
        IFreezable Deposit();
        IFreezable Withdraw();

        // the explicit request to freeze the account
        IFreezable Freeze();
    }
}
