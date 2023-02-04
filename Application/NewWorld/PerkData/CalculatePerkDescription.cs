using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application.Common.DynamicEvaluator;

namespace Application.NewWorld.PerkData
{
    public record CalculatePerkDescriptionRequest(string Description, string? ItemClassGSBonus, double? ScalingPerGearScore) : IRequest<string>;

    public class CalculatePerkDescriptionRequestHandler : IRequestHandler<CalculatePerkDescriptionRequest, string>
    {
        private readonly IDynamicEvaluator dynamicEvaluator;

        public CalculatePerkDescriptionRequestHandler(IDynamicEvaluator dynamicEvaluator)
        {
            this.dynamicEvaluator = dynamicEvaluator;
        }

        public async ValueTask<string> Handle(CalculatePerkDescriptionRequest request, CancellationToken cancellationToken)
        {
            var finalDescription = request.Description;

            Regex rx = new Regex(@"(?<=\{\[)(.*?)(?=\]\})");
            var regexResult = rx.Matches(request.Description);
            foreach(var match in regexResult)
            {
                var evalExpress = match.ToString() ?? "";
                var desc = await Eval(evalExpress, request.Description, request.ScalingPerGearScore);

                finalDescription = finalDescription.Replace(evalExpress, desc);
                //if(!finalDescription.Contains("perkMultiplier")) finalDescription = finalDescription.Replace("{[", "").Replace("]}", "").ToString();
            }

            return finalDescription;
        }

        private async Task<string> Eval(string evalExpress, string perkDescription, double? scalingPerGearScore)
        {
            if (evalExpress.Contains("{perkMultiplier}"))
            {
                var tmpEvalExpress = evalExpress.Replace("{perkMultiplier}", "1").Replace("[", "").Replace("]", "");
                try
                {
                    var evaluated = await dynamicEvaluator.EvaluateExpression(tmpEvalExpress); 
                    var baseValue = Convert.ToDouble(evaluated);
                    return baseValue.ToString() + " * {perkMultiplier}";
                }
                catch (Exception)
                {
                    tmpEvalExpress = evalExpress.Replace("{perkMultiplier}", "*1").Replace("[", "").Replace("]", "");
                    var evaluated = await dynamicEvaluator.EvaluateExpression(tmpEvalExpress);
                    var baseValue = Convert.ToDouble(evaluated);
                    return baseValue.ToString() + " * {perkMultiplier}";
                }
                
            }
            else
            {
                var result = await dynamicEvaluator.EvaluateExpression(evalExpress);
                //perkDescription = perkDescription.Replace("" + evalExpress + "", result.ToString());

                return result?.ToString();
            }
        }
    }

    
}
