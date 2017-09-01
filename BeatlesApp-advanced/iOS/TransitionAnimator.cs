using CoreGraphics;
using UIKit;

namespace BeatlesApp.iOS
{
    public class TransitionAnimator : UIViewControllerAnimatedTransitioning
    {
        private const double _duration = 0.5;

        public CGRect ThumbnailFrame { get; set; }
        public UINavigationControllerOperation Operation { get; set; }

        public override void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
        {
            var presenting = Operation == UINavigationControllerOperation.Push;

            // Determine which is the master view and which is the detail view that we're navigating to and from. The container view will house the views for transition animation.
            var containerView = transitionContext.ContainerView;
            var toView = transitionContext.GetViewFor(UITransitionContext.ToViewKey);
            var fromView = transitionContext.GetViewFor(UITransitionContext.FromViewKey);

            var storyFeedView = presenting ? fromView : toView;
            var storyDetailView = presenting ? toView : fromView;

            // Determine the starting frame of the detail view for the animation. When we're presenting, the detail view will grow out of the thumbnail frame. When we're dismissing, the detail view will shrink back into that same thumbnail frame.
            var initialFrame = presenting ? ThumbnailFrame : storyDetailView.Frame;
            var finalFrame = presenting ? storyDetailView.Frame : ThumbnailFrame;

            // Resize the detail view to fit within the thumbnail's frame at the beginning of the push animation and at the end of the pop animation while maintaining it's inherent aspect ratio.
            var initialFrameAspectRatio = initialFrame.Width / initialFrame.Height;
            var storyDetailAspectRatio = storyDetailView.Frame.Width / storyDetailView.Frame.Height;

            if (initialFrameAspectRatio > storyDetailAspectRatio)
            {
                initialFrame.Size = new CGSize(initialFrame.Height * storyDetailAspectRatio, initialFrame.Height);
            }
            else
            {
                initialFrame.Size = new CGSize(initialFrame.Width, initialFrame.Width / storyDetailAspectRatio);
            }

            var finalFrameAspectRatio = finalFrame.Width / finalFrame.Height;
            var resizedFinalFrame = finalFrame;
            if (finalFrameAspectRatio > storyDetailAspectRatio)
            {
                resizedFinalFrame.Size = new CGSize(finalFrame.Height * storyDetailAspectRatio, finalFrame.Height);
            }
            else
            {
                resizedFinalFrame.Size = new CGSize(finalFrame.Width, finalFrame.Width / storyDetailAspectRatio);
            }

            // Determine how much the detail view needs to grow or shrink.
            var scaleFactor = resizedFinalFrame.Width / initialFrame.Width;
            var growScaleFactor = presenting ? scaleFactor : 1 / scaleFactor;
            var shrinkScaleFactor = 1 / growScaleFactor;

            if (presenting)
            {
                // Shrink the detail view for the initial frame. The detail view will be scaled to CGAffineTransformIdentity below.
                storyDetailView.Transform = CGAffineTransform.MakeScale(shrinkScaleFactor, shrinkScaleFactor);
                storyDetailView.Center = new CGPoint(ThumbnailFrame.GetMidX(), ThumbnailFrame.GetMidY());
                storyDetailView.ClipsToBounds = true;

            }

            // Set the initial state of the alpha for the master and detail views so that we can fade them in and out during the animation.
            storyDetailView.Alpha = presenting ? 0 : 1;
            storyFeedView.Alpha = presenting ? 1 : 0;

            // Add the view that we're transitioning to to the container view that houses the animation.
            containerView.AddSubview(toView);
            containerView.BringSubviewToFront(storyDetailView);

            // Animate the transition.
            UIView.Animate(_duration, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                // Fade the master and detail views in and out.
                storyDetailView.Alpha = presenting ? 1 : 0;
                storyFeedView.Alpha = presenting ? 0 : 1;

                if (presenting)
                {
                    // Scale the master view in parallel with the detail view (which will grow to its inherent size). The translation gives the appearance that the anchor point for the zoom is the center of the thumbnail frame.
                    var scale = CGAffineTransform.MakeScale(growScaleFactor, growScaleFactor);
                    var translate = CGAffineTransform.Translate(storyFeedView.Transform, storyFeedView.Frame.GetMidX() - this.ThumbnailFrame.GetMidX(), storyFeedView.Frame.GetMidY() - this.ThumbnailFrame.GetMidY());

                    storyFeedView.Transform = translate * scale;
                    storyDetailView.Transform = CGAffineTransform.MakeIdentity();
                }
                else
                {
                    // Return the master view to its inherent size and position and shrink the detail view.
                    storyFeedView.Transform = CGAffineTransform.MakeIdentity();
                    storyDetailView.Transform = CGAffineTransform.MakeScale(shrinkScaleFactor, shrinkScaleFactor);
                }

                // Move the detail view to the final frame position.
                storyDetailView.Center = new CGPoint(finalFrame.GetMidX(), finalFrame.GetMidY());
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
