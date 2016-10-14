using Bezysoftware.Navigation.Lookup;
using example_windows_app.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace example_windows_app
{
    [AssociatedViewModel(typeof(ArticlePageViewModel))]
    public sealed partial class ArticlePage : Page
    {
        public ArticlePage()
        {
            this.InitializeComponent();
        }
    }
}
