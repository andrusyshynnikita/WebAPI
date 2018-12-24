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
        public TextView Title { get; set; }
        public CheckBox Status { get; set; }


        public TaskItemHolder(View itemview, IMvxAndroidBindingContext context, Action<int> listener) : base(itemview, context)

        {
            Title = itemview.FindViewById<TextView>(Resource.Id.textView);
            Status = itemview.FindViewById<CheckBox>(Resource.Id.statusInfo);
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TaskItemHolder, TaskInfo>();
                set.Bind(this.Title).To(x => x.Title);
                set.Bind(this.Status).To(x => x.Status);
                set.Apply();
            });
            itemview.Click += (sender, e) => listener(base.AdapterPosition);
        }
    }
}