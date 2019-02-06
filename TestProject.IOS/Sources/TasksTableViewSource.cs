using System;
using System.Linq;
using Foundation;
using MvvmCross.Base;
using MvvmCross.Binding.Extensions;
using MvvmCross.Platforms.Ios.Binding.Views;
using TestProject.Core.Models;
using TestProject.IOS.Views.Cells;
using UIKit;

namespace TestProject.IOS.Sources
{
    public class TasksTableViewSource : MvxTableViewSource
    {

        public TasksTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var group = ItemsSource.ElementAt(indexPath.Row) as TaskInfo; 

            var cell = GetOrCreateCellFor(tableView, indexPath, group);
            return cell;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = tableView.DequeueReusableCell(TasksViewCell.Key) as TasksViewCell;

            if (cell == null)
            {
                cell = TasksViewCell.Create();
            }

            var bindable = cell as IMvxDataConsumer;
            if (bindable != null)
                bindable.DataContext = item;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ItemsSource.Count();
        }
    }
}
