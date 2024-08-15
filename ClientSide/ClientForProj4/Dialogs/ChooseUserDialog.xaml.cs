using LMSLibrary;
using LMSLibrary.Models;
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
    public sealed partial class ChooseUserDialog : ContentDialog
    {
        public Person User;
        public ChooseUserDialog(ObservableCollection<Person> people, Person person)
        {
            this.InitializeComponent();
            DataContext = new PersonVeiwModel(people, person);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (PersonList.SelectedItem != null)
            {
                (DataContext as PersonVeiwModel).SelectUser();
                User = (PersonList.SelectedItem as Person);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as PersonVeiwModel).SearchUser();
        }
    }
}
