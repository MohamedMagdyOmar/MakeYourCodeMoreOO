using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._010.Turning_Function_into_a_State
{
    class Active :IFreezable
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            // will be initialzed one time, and will remain with us
            // in the entire life of the object.
            this.OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit() => this;

        public IFreezable Withdraw() => this;

        // it change the state of the account, it return new frozen state
        // and active state has to provide its own OnUnfreezeAction.
        public IFreezable Freeze() => new Frozen(this.OnUnfreeze);
    }
}
