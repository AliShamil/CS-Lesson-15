using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lesson_15;

internal class Reception
{
    public Patient? ReservedPatient { get; set; }

    public TimeOnly RandevuTimeStart { get; set; }
    public TimeOnly RandevuTimeEnd { get; set; }

    public Reception(TimeOnly randevuTimeStart, TimeOnly randevuTimeEnd)
    {
        RandevuTimeStart=randevuTimeStart;
        RandevuTimeEnd=randevuTimeEnd;
        ReservedPatient=null;
    }

    public override string ToString()
=> $@"Randevu Time: {RandevuTimeStart} - {RandevuTimeEnd}

Reserved Patient: 

{(ReservedPatient == null ? "EMPTY" : ReservedPatient)}";
}
