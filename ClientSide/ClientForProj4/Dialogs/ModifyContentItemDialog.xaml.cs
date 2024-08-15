using LMSLibrary;
using Project_3___3.Veiw_Model;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_3___3.Dialogs
{
    public sealed partial class ModifyContentItemDialog : ContentDialog
    {
        public ModifyContentItemDialog(List<ContentItem> contentItems, String selected)
        {
            this.InitializeComponent();
            DataContext = new ContentItemViewModel(contentItems, selected);
            if ((DataContext as ContentItemViewModel).PageItem.Name != "")
            {
                HTMLText.Visibility = Visibility.Visible;
                HTMLTextBox.Visibility = Visibility.Visible;
            }
            else if ((DataContext as ContentItemViewModel).FileItem.Name != "")
            {
                FileText.Visibility = Visibility.Visible;
                FileTextBox.Visibility = Visibility.Visible;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
  
            (DataContext as ContentItemViewModel).ModifyContentItem();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
