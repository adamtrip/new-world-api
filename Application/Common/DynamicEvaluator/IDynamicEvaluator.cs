using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DynamicEvaluator
{
    public interface IDynamicEvaluator
    {
        Task<object> EvaluateExpression(string expression);
    }
}
