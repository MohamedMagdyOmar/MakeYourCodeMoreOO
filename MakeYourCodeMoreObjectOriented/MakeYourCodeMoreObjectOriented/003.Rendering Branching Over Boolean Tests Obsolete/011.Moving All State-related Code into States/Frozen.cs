using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._010.Turning_Function_into_a_State
{
    class Frozen2 : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Frozen2(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnfreeze();
            addToBalance();
            return new Active2(this.OnUnfreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.OnUnfreeze();
            subtractFromBalance();
            return new Active2(this.OnUnfreeze);
        }

        public IAccountState Freeze() => this;


        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}
