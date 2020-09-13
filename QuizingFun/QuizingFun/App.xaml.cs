
using Xamarin.Forms;

namespace QuizingFun
{
    public partial class App : Application
    {
        /* Main Page is initialized as a navigation page and the page that needs to load initially as a new NavigationPage*/
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());    
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
