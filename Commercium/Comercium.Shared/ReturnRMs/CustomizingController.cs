using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.ReturnRMs
{
    public class CustomizingController : ControllerBase
    {
        public static IActionResult CreateReturn<T>(ReturnRM<T> returnRM)
        {
            return new ObjectResult(returnRM)
            {
                StatusCode = returnRM.StatusCode
            };
        }
    }
}
