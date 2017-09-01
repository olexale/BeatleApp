using System.Linq;
using Xamarin.Forms;

namespace BeatlesApp
{
    public class TagEffect : RoutingEffect
    {
        public TagEffect() : base("BeatlesApp.TagEffect")
        {
        }

        public static readonly BindableProperty TagProperty =
            BindableProperty.CreateAttached("Tag", typeof(int), typeof(TagEffect), 0, propertyChanged: OnTagChanged);

        public static int GetTag(BindableObject view)
        {
            return (int)view.GetValue(TagProperty);
        }

        public static void SetTag(BindableObject view, int value)
        {
            view.SetValue(TagProperty, value);
        }

        static void OnTagChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            var tag = (int)newValue;
            if (tag > 0)
            {
                view.Effects.Add(new TagEffect());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is TagEffect);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
        }
    }
}
