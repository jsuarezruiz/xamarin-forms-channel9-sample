using Channel9.iOS.Renderers;
using Channel9.Views;
using CoreGraphics;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HomeView), typeof(LogoPageRenderer))]
namespace Channel9.iOS.Renderers
{
    public class LogoPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var image = UIImage.FromBundle("channel9_logo.png");
            var imageView = new UIImageView(new CGRect(0, 0, 140, 70))
            {
                ContentMode = UIViewContentMode.ScaleAspectFit,
                Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal)
            };

            if (NavigationController != null)
            {
                NavigationController.TopViewController.NavigationItem.TitleView = imageView;
            }
        }
    }
}