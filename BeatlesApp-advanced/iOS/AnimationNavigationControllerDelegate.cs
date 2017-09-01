using System;
using UIKit;

namespace BeatlesApp.iOS
{
    public class AnimationNavigationControllerDelegate : UINavigationControllerDelegate
    {
        private TransitionAnimator _animator = new TransitionAnimator();
        private int _id;

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForOperation(UINavigationController navigationController, UINavigationControllerOperation operation, UIViewController fromViewController, UIViewController toViewController)
        {
            if (operation == UINavigationControllerOperation.Push)
            {
                var image = fromViewController.View.ViewWithTag(_id);
                var convertedFrame = image.ConvertRectToView(image.Bounds, fromViewController.View);
                _animator.ThumbnailFrame = convertedFrame;
            }
            _animator.Operation = operation;
            return _animator;
        }

        internal void SetTransitionId(int id)
        {
            _id = id;
        }
    }
}
