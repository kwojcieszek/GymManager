using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Microsoft.Xaml.Behaviors;
using Throttle;

namespace GymManager.Common.DataGridExtensions
{
    /// <summary>
    ///     A behavior to control the "ApplyInitialSorting" feature.
    /// </summary>
    public class ApplyInitialSortingBehavior : Behavior<DataGrid>
    {
        public IList<KeyValuePair<string, ListSortDirection>> MostRecentDescriptions { get; set; }

        private IList<KeyValuePair<string, ListSortDirection>> _lastKnownActiveDescriptions =
            new List<KeyValuePair<string, ListSortDirection>>();

        private object _lastSelectedObject;

        /// <summary>
        ///     Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        ///     Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();

            var dataGrid = AssociatedObject;

            ((INotifyCollectionChanged)dataGrid.Items.SortDescriptions).CollectionChanged +=
                SortDescriptions_CollectionChanged;

            DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid))
                .AddValueChanged(dataGrid, ItemsSource_Changed);
        }

        /// <summary>
        ///     Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        ///     Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            var dataGrid = AssociatedObject;

            ((INotifyCollectionChanged)dataGrid.Items.SortDescriptions).CollectionChanged -=
                SortDescriptions_CollectionChanged;

            DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid))
                .RemoveValueChanged(dataGrid, ItemsSource_Changed);
        }

        internal static void IsEnabled_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if(sender is not DataGrid dataGrid)
            {
                return;
            }

            var behaviors = Interaction.GetBehaviors(dataGrid);

            var existing = behaviors.FirstOrDefault(b => b is ApplyInitialSortingBehavior);

            if(true.Equals(e.NewValue))
            {
                if(existing == null)
                {
                    behaviors.Add(new ApplyInitialSortingBehavior());
                }
            }
            else
            {
                behaviors.Remove(existing);
            }
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        private void ItemsSource_Changed(object? sender, EventArgs e)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            try
            {
                var dataGrid = AssociatedObject;
                var dataGridItems = dataGrid.Items;

                if(_lastKnownActiveDescriptions.Count == 0)
                {
                    return;
                }

                if(_lastKnownActiveDescriptions.Any() && !dataGridItems.SortDescriptions.Any())
                {
                    foreach(var item in _lastKnownActiveDescriptions)
                    {
                        var column = dataGrid.Columns.FirstOrDefault(col => col.SortMemberPath == item.Key);

                        if(column != null)
                        {
                            column.SortDirection = item.Value;
                        }
                    }
                }

                var groupDescriptions = dataGridItems.GroupDescriptions;

                dataGridItems.SortDescriptions.Clear();

                foreach(var groupDescription in groupDescriptions.OfType<PropertyGroupDescription>())
                {
                    dataGridItems.SortDescriptions.Add(new SortDescription(groupDescription.PropertyName,
                        ListSortDirection.Ascending));
                }

                foreach(var column in dataGrid.Columns.Where(c =>
                            c?.SortDirection != null && !string.IsNullOrEmpty(c.SortMemberPath)))
                {
                    dataGridItems.SortDescriptions.Add(new SortDescription(column.SortMemberPath,
                        column.SortDirection.GetValueOrDefault()));
                }

                dataGrid.SelectedValue = _lastSelectedObject;

                _lastSelectedObject = null;
            }
            catch(InvalidOperationException)
            {
                // in some special cases we may get:
                // System.InvalidOperationException: 'Sorting' is not allowed during an AddNew or EditItem transaction.
                // => just ignore, there is nothing we can do about it...
            }
        }

        [Throttled(typeof(DispatcherThrottle), (int)DispatcherPriority.Normal)]
        private void PersistLastKnownSortDescriptions()
        {
            _lastKnownActiveDescriptions = MostRecentDescriptions ?? _lastKnownActiveDescriptions;
        }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        private void SortDescriptions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            var dataGrid = AssociatedObject;

            if(_lastSelectedObject == null && e.Action == NotifyCollectionChangedAction.Reset)
            {
                _lastSelectedObject = dataGrid.SelectedValue;
            }

            MostRecentDescriptions = dataGrid.Items.SortDescriptions
                .Skip(dataGrid.Items.GroupDescriptions.Count)
                .Select(s => new KeyValuePair<string, ListSortDirection>(s.PropertyName, s.Direction))
                .ToList();

            PersistLastKnownSortDescriptions();
        }
    }
}