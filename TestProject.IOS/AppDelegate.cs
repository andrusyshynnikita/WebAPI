using Foundation;
using MvvmCross.Platforms.Ios.Core;
using TestProject.Core;
using UIKit;

namespace TestProject.IOS
{

    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);
            return result;
        }
    }
}

