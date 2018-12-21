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
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using TestProject.Core.Models;
using TestProject.Core.ViewModels;
using static Android.Support.V7.Widget.RecyclerView;

namespace TestProject.Droid
{
    public class TaskItemHolder : MvxRecyclerViewHolder
    {
        public TextView TaskName { get; set; }
        public CheckBox TaskStatus { get; set; }


        public TaskItemHolder(View itemview, IMvxAndroidBindingContext context) : base(itemview, context)

        {
            TaskName = itemview.FindViewById<TextView>(Resource.Id.textView);
            TaskStatus = itemview.FindViewById<CheckBox>(Resource.Id.statusInfo);
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TaskItemHolder, TaskInfo>();
                set.Bind(this.TaskName).To(x => x.TaskName);
                set.Bind(this.TaskStatus).To(x => x.TaskStatus);
                set.Apply();
            });
        }
    }
}