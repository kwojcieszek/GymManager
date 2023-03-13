﻿using MahApps.Metro.Controls;

namespace GymManager.Views.Test
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            HamburgerMenuControl.SetCurrentValue(ContentProperty, e.ClickedItem);
            HamburgerMenuControl.SetCurrentValue(HamburgerMenu.IsPaneOpenProperty, false);
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}