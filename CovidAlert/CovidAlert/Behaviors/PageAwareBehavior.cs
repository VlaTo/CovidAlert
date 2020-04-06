using System;
using CovidAlert.Core;
using Xamarin.Forms;

namespace CovidAlert.Behaviors
{
    public class PageAwareBehavior : Behavior<Page>
    {
        protected override void OnAttachedTo(Page page)
        {
            base.OnAttachedTo(page);
            page.Appearing += OnPageAppearing;
        }

        protected override void OnDetachingFrom(Page page)
        {
            base.OnDetachingFrom(page);
            page.Appearing -= OnPageAppearing;
        }

        private async void OnPageAppearing(object sender, EventArgs e)
        {
            if (sender is VisualElement element)
            {
                if (element.BindingContext is IInitializeAsync context)
                {
                    await context.InitializeAsync();
                }
            }
        }
    }
}