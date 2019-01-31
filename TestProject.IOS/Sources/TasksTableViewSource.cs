using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Base;
using MvvmCross.Binding.Extensions;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.ViewModels;
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
            var group = ItemsSource.ElementAt(indexPath.Row) as TaskInfo; //as MvxObservableCollection<TaskInfo>;
            //var item = group.ElementAt(indexPath.Row) as TaskInfo;

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

        //public override nint NumberOfSections(UITableView tableView)
        //{
        //    return ItemsSource.Count();
        //}

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            //MvxObservableCollection<TaskInfo> group = ItemsSource.ElementAt((int)section) as MvxObservableCollection<TaskInfo>;
            //return group.Count();
            return ItemsSource.Count();
        }

        //public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        //{
        //    base.RowS elected(tableView, indexPath);
        //}
        //public override string TitleForHeader(UITableView tableView, nint section)
        //{
        //    return string.Format($"Header for section {section}");
        //}
    }
}
