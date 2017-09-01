using System;
using UIKit;

namespace BeatlesApp.iOS
{
    public class AnimationNavigationControllerDelegate : UINavigationControllerDelegate
    {
        private TransitionAnimator _animator = new TransitionAnimator();

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForOperation(UINavigationController navigationController, UINavigationControllerOperation operation, UIViewController fromViewController, UIViewController toViewController)
        {
            return _animator;
        }
    }
}
