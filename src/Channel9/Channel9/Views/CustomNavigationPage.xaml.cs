using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;

namespace Channel9.Views
{
    public partial class CustomNavigationPage : Xamarin.Forms.NavigationPage
    {
        public CustomNavigationPage() : base()
        {
            InitializeComponent();
        }

        public CustomNavigationPage(Page root) : base(root)
        {
            InitializeComponent();

            this.On<GTK>().SetBackButtonIcon("Images/channel9-back.png");
        }
    }
}