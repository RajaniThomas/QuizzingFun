using Xamarin.UITest;

namespace QuizzingFun.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.quizingfun").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}