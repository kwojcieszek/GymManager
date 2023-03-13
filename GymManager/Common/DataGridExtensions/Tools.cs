using System.Windows;
using System.Windows.Controls;

namespace GymManager.Common.DataGridExtensions
{
    /// <summary>
    ///     Some useful tools for data grids.
    /// </summary>
    public static class Tools
    {
        public static readonly DependencyProperty ApplyInitialSortingProperty =
            DependencyProperty.RegisterAttached("ApplyInitialSorting", typeof(bool), typeof(Tools),
                new FrameworkPropertyMetadata(false, ApplyInitialSortingBehavior.IsEnabled_Changed));

        /// <summary>
        ///     Gets the flag to enable the 'apply initial sorting' feature.
        /// </summary>
        /// <param name="dataGrid">The data grid.</param>
        /// <returns><c>true</c> if 'apply initial sorting is enabled.'</returns>
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        public static bool GetApplyInitialSorting(this DataGrid dataGrid)
        {
            return (bool)dataGrid.GetValue(ApplyInitialSortingProperty);
        }

        public static void SetApplyInitialSorting(this DataGrid dataGrid, bool value)
        {
            dataGrid.SetValue(ApplyInitialSortingProperty, value);
        }
    }
}