using System.Threading.Tasks;

namespace CovidAlert.Interaction.Extensions
{
    internal static class InteractionRequestExtension
    {
        public static Task RaiseAndWait<TContext>(this InteractionRequest<TContext> request, TContext context)
            where TContext : InteractionRequestContext
        {
            var tcs = new TaskCompletionSource<bool>();

            request.Raise(context, () => tcs.SetResult(true));

            return tcs.Task;
        }
    }
}