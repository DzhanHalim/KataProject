using Business.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessRules
{
   public class BusinessRule
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }

            }
            return null;
        }
    }
}
