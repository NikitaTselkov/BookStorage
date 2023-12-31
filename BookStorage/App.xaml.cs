﻿using BookStorage.ViewModels.Dialogs;
using BookStorage.Views;
using BookStorage.Views.Dialogs;
using Core;
using DataBaseAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Services;
using System.Globalization;
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
            TranslationSource.Instance.CurrentCulture = new CultureInfo("en");

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IBookRepository, BookRepository>();
            containerRegistry.RegisterSingleton<IBookThemeService, BookThemeService>();

            containerRegistry.RegisterSingleton<ISettingsService, AppSettingsService>();

            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
            containerRegistry.RegisterDialog<UpsertDialog, UpsertDialogViewModel>();
        }
    }
}
