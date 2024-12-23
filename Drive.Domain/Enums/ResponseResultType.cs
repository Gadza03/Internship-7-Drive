using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Domain.Enums
{
    public enum ResponseResultType
    {
        Success,
        NotFound,
        AlreadyExists,
        NoChanges,
        ValidationError
    }
}
