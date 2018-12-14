using System;
using MvvmCross;
using MvvmCross.ViewModels;
using MvvmCross.IoC;


namespace TestProject.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.ViewModel>();
        }
    }
}
