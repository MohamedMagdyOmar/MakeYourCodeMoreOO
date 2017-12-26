using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004.Keeping_the_Focus_on_Domain_Logic_with_Sequences
{
   public interface IPainter
    {
        bool IsAvailable { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }
}
