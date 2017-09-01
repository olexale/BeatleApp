using BeatlesApp.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("BeatlesApp")]
[assembly: ExportEffect(typeof(TagEffect), "TagEffect")]
namespace BeatlesApp.iOS
{
    public class TagEffect : PlatformEffect
    {
        private System.nint _tag;

        protected override void OnAttached()
        {
            _tag = Control.Tag;
            Control.Tag = BeatlesApp.TagEffect.GetTag(Element);
        }

        protected override void OnDetached()
        {
            Control.Tag = _tag;
        }
    }
}
