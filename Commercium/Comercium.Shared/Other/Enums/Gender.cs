using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Other.Enums
{
    public enum Gender
    {
        Male = 1,  // erkek
        Female = 2, // kadın
        NonBinary = 3,  // erkek veya kadın diye  birine tam olarak uymadığını hissederler
        Other = 4,  // diğer cinsiyetler
        PreferNotToSay = 5 // söylemeyi tercih etmiyor
    }
}
