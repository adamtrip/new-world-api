namespace Application.Common.DynamicEvaluator
{
    public interface IDynamicEvaluator
    {
        Task<object> EvaluateExpression(string expression);
    }
}
