using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreObjectOriented._003.Rendering_Branching_Over_Boolean_Tests_Obsolete._010.Turning_Function_into_a_State
{
    class Frozen : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            // will be initialzed one time, and will remain with us
            // in the entire life of the object.
            this.OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit()
        {
            this.OnUnfreeze();
            return new Active(this.OnUnfreeze);
        }

        public IFreezable Withdraw()
        {
            this.OnUnfreeze();
            return new Active(this.OnUnfreeze);
        }

        // it will do nothing because current state is already as
        // requested by the caller
        public IFreezable Freeze() => this;
    }
}
