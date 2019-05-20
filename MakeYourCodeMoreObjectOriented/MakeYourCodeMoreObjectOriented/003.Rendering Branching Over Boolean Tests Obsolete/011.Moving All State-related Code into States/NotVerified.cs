using MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._010.Turning_Function_into_a_State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._011.Moving_All_State_related_Code_into_States
{
    // new state
    class NotVerified: IAccountState
    {
        private Action OnUnfreeze { get; }

        public NotVerified(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        // if not verified you can not withdraw. so ignore the call.
        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active2(this.OnUnfreeze);

        public IAccountState Close() => new Closed();
    }
}
