// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TestProject.IOS
{
    [Register ("NotDoneListItemView")]
    partial class NotDoneListItemView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView NotDoneTasksTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NotDoneTasksTableView != null) {
                NotDoneTasksTableView.Dispose ();
                NotDoneTasksTableView = null;
            }
        }
    }
}