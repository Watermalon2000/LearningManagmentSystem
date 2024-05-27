﻿using LMSLibrary;
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
    public sealed partial class ModifyCourseDialog : ContentDialog
    {
        public ModifyCourseDialog(Dictionary<String, Course> coures, String selected)
        {
            this.InitializeComponent();
            DataContext = new CourseVeiwModel(coures, selected);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            (DataContext as CourseVeiwModel).ModifyCourse();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
