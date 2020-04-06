using System;

namespace CovidAlert.Interaction
{
    public interface IInteractionRequest
    {
        event EventHandler<InteractionRequestEventArgs> Raised;
    }
}