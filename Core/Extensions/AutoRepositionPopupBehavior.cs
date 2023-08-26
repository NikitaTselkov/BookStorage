using System.Windows.Controls.Primitives;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace Core.Extensions
{
    public class AutoRepositionPopupBehavior : Behavior<Popup>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            Window w = Window.GetWindow(AssociatedObject.PlacementTarget);

            if (null != w)
            {
                w.LocationChanged += (sender, args) =>
                {
                    var offset = AssociatedObject.HorizontalOffset;
                    AssociatedObject.HorizontalOffset = offset + 1;
                    AssociatedObject.HorizontalOffset = offset;
                };
            }
        }
    }
}
