﻿using BookStorage.Views;
using DataBaseAccess.Repository;
using Prism.Ioc;
using System.Windows;

namespace BookStorage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IBookRepository, BookRepository>();
        }
    }
}
