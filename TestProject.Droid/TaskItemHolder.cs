using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace TestProject.Droid
{
    public class TaskItemHolder : MvxRecyclerView.ViewHolder
    {
        public TextView TaskName { get; set; }
        public TextView TaskStatus { get; set; }

        public TaskItemHolder(View itemview) : base(itemview)

        {
            TaskName = itemview.FindViewById<TextView>(Resource.Id.textView);
        }
    }
}