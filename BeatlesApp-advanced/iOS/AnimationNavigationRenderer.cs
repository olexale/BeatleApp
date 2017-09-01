using System;
using BeatlesApp.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(AnimationNavigationRenderer))]
namespace BeatlesApp.iOS
{
    public class AnimationNavigationRenderer : Xamarin.Forms.Platform.iOS.NavigationRenderer
    {
        private AnimationNavigationControllerDelegate _delegate;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _delegate = new AnimationNavigationControllerDelegate();
            Delegate = _delegate;

            MessagingCenter.Subscribe<object, int>(this, "TransitionId", (sender, arg) =>
            {
                _delegate.SetTransitionId(arg);
            });
        }
    }
}
