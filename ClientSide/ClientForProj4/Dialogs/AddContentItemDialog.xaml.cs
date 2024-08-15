using LMSLibrary;
using Project_3___3.Veiw_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_3___3.Dialogs
{
    public sealed partial class AddContentItemDialog : ContentDialog
    {

        private int type = 0;
        public AddContentItemDialog(List<ContentItem> contentItems, ObservableCollection<Assignment> assignments)
        {
            this.InitializeComponent();
            DataContext = new ContentItemViewModel(contentItems, assignments);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (AssignmentList.SelectedItem != null)
            {
                (DataContext as ContentItemViewModel).AddContentItem(type, (AssignmentList.SelectedItem as Assignment));
            }
            else
            {
                (DataContext as ContentItemViewModel).AddContentItem(type);
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ContentItemViewModel).SearchContentItem();
        }

        private void Handle_Check(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Name == "Assignment")
            {
                type = 0;
                AssignmentList.Visibility = Visibility.Visible;
                SearchBox.Visibility = Visibility.Visible;
                SearchButton.Visibility = Visibility.Visible;
                PageText.Visibility = Visibility.Collapsed;
                PageTextBox.Visibility = Visibility.Collapsed;
                FileText.Visibility = Visibility.Collapsed;
                FileTextBox.Visibility = Visibility.Collapsed;

            }
            else if (rb.Name == "Page")
            {
                type = 1;
                AssignmentList.Visibility = Visibility.Collapsed;
                SearchBox.Visibility = Visibility.Collapsed;
                SearchButton.Visibility = Visibility.Collapsed;
                PageText.Visibility = Visibility.Visible;
                PageTextBox.Visibility = Visibility.Visible;
                FileText.Visibility = Visibility.Collapsed;
                FileTextBox.Visibility = Visibility.Collapsed;
            }
            else if (rb.Name == "File")
            {
                type = 2;
                AssignmentList.Visibility = Visibility.Collapsed;
                SearchBox.Visibility = Visibility.Collapsed;
                SearchButton.Visibility = Visibility.Collapsed;
                PageText.Visibility = Visibility.Collapsed;
                PageTextBox.Visibility = Visibility.Collapsed;
                FileText.Visibility = Visibility.Visible;
                FileTextBox.Visibility = Visibility.Visible;
            }
        }
    }
}
