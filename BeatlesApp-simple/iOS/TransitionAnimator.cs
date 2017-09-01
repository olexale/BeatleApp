using UIKit;

namespace BeatlesApp.iOS
{
    public class TransitionAnimator : UIViewControllerAnimatedTransitioning
    {
        private const double _duration = 0.5;

        public override void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
        {
            var containerView = transitionContext.ContainerView;
            var toView = transitionContext.GetViewFor(UITransitionContext.ToViewKey);

            containerView.AddSubview(toView);
            toView.Alpha = 0;
            UIView.Animate(_duration, () =>
            {
                toView.Alpha = 1;
            }, () =>
            {
                transitionContext.CompleteTransition(true);
            });
        }

        public override double TransitionDuration(IUIViewControllerContextTransitioning transitionContext)
        {
            return _duration;
        }
    }
}
