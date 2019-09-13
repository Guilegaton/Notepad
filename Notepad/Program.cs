using Notepad.DAL.Interfaces;
using Notepad.DAL.Repositories;
using Notepad.Forms;
using SimpleInjector;
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
            Application.Run(_container.GetInstance<MainMenuForm>());
        }

        private static void Bootstrap()
        {
            _container = new Container();

            _container.Register<FileSelectForm>();
            _container.Register<FileNameForm>();
            _container.Register<MainMenuForm>();
            _container.Register<ApplicationContext>();
            _container.Register<IFileRepository, FileRepository>();

            _container.Verify();
        }
    }
}
