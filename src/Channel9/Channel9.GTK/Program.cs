using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace Channel9.GTK
{
    class Program
    {
        public static object VideoViewRenderer { get; private set; }

        static void Main(string[] args)
        {
            Gtk.Application.Init();
            Forms.Init();
            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("Channel 9");
            window.SetApplicationIcon("Images/channel9-logo.png");
            window.Show();
            Gtk.Application.Run();
        }
    }
}