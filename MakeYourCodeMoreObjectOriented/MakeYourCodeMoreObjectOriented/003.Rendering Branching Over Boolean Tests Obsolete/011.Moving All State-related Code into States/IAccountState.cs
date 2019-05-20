using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._010.Turning_Function_into_a_State
{
    // since this interface will not handle only Freezable state, but also verification and closing state,
    // so we are going to change the name of the interface from IFreezable to IAccountState

    // State Patter Consequences:
    // 1- no more branching
    // 2- Runtime type of the state object replaces branching
    // 3- Dynamic dispatch used to choose one Implementation or the other
    interface IAccountState
    {

        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Freeze();

        // the 2 new state
        IAccountState HolderVerified();
        IAccountState Close();
    }
}
