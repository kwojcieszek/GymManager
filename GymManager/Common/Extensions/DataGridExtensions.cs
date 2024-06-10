using System.Windows;
using System.Windows.Controls;
using GymManager.Common.DataGrid;

namespace GymManager.Common.Extensions
{
    public static class DataGridExtensions
    {
        public static readonly DependencyProperty ApplyInitialSortingProperty =
            DependencyProperty.RegisterAttached("ApplyInitialSorting", typeof(bool), typeof(DataGridExtensions),
                new FrameworkPropertyMetadata(false, ApplyInitialSortingBehavior.IsEnabled_Changed));

        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.DataGrid))]
        public static bool GetApplyInitialSorting(this System.Windows.Controls.DataGrid dataGrid)
        {
            return (bool)dataGrid.GetValue(ApplyInitialSortingProperty);
        }

        public static void SetApplyInitialSorting(this System.Windows.Controls.DataGrid dataGrid, bool value)
        {
            dataGrid.SetValue(ApplyInitialSortingProperty, value);
        }
    }
}