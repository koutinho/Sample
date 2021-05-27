using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleTestApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            Theme theme = new Theme("UnitelTheme");
            theme.AssemblyName = "DevExpress.Xpf.Themes.UnitelTheme.v20.2";
            Theme.RegisterTheme(theme);

            GalaSoft.MvvmLight.Threading.DispatcherHelper.Initialize();
        }

        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await PreloadModules();
        }

        private async Task PreloadModules()
        {
            Assembly gridassembly = Assembly.LoadFrom("DevExpress.Xpf.Grid.v20.2.dll");
            await ThemeManager.PreloadThemeResourceAsync("UnitelTheme");
        }
    }
}
