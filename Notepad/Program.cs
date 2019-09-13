using Notepad.DAL.Interfaces;
using Notepad.DAL.Repositories;
using Notepad.Forms;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    static class Program
    {
        private static Container _container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            using (AsyncScopedLifestyle.BeginScope(_container))
            {
                Application.Run(_container.GetInstance<MainMenuForm>());
            }
        }

        private static void Bootstrap()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            _container.Register<IFileRepository, FileRepository>(Lifestyle.Scoped);
            _container.Register<DataProcessingService>(Lifestyle.Scoped);
            _container.Register<FileSelectForm>(Lifestyle.Scoped);
            _container.Register<FileNameForm>(Lifestyle.Scoped);
            _container.Register<MainMenuForm>(Lifestyle.Scoped);
            _container.Register<DAL.ApplicationContext>(Lifestyle.Scoped);

            _container.Verify();
        }
    }
}
