using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleAudioPlayer
{
    /// <summary>
    /// Interaction logic for BrowserTesting.xaml
    /// </summary>
    public partial class BrowserTesting : Window
    {
        public BrowserTesting()
        {
            InitializeComponent();
			txtUrl.IsReadOnly = true;
			WBBrowser.Navigate("https://www.youtube.com/");
        }

		private void txtUrl_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
				WBBrowser.Navigate(txtUrl.Text);
		}

		private void WBBrowser_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
		{
			if(!e.Uri.ToString().Contains("https://www.youtube.com/"))
			txtUrl.Text = e.Uri.OriginalString;
		}

		private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ((WBBrowser != null) && (WBBrowser.CanGoBack));
		}

		private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			WBBrowser.GoBack();
		}

		private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ((WBBrowser != null) && (WBBrowser.CanGoForward));
		}

		private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			WBBrowser.GoForward();
		}

		private void GoToPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void GoToPage_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			WBBrowser.Navigate(txtUrl.Text);
		}

		private void btnAddSong_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(WBBrowser.Source.AbsoluteUri);
		}
	}
}
