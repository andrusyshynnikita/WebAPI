using Android.Support.V7.Widget;
using Android.Views;
using System;
using MvvmCross.Droid.Support.V7.AppCompat.Widget;
using Android.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView;
using TestProject.Core.Models;
using MvvmCross.ViewModels;
using Android.Widget;
using TestProject.Droid;
using MvvmCross.Droid.Support.V7.AppCompat;
using Resource = TestProject.Droid.Resource;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace testproject.droid
{
    public class TasksItemAdapter : MvxRecyclerAdapter
    {
       // private MvxObservableCollection<TaskInfo> _taskcollection;
        public EventHandler<int> ItemClick;

        public TasksItemAdapter(IMvxAndroidBindingContext bindingContext)
            : base(bindingContext)
        {
        }
      
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.task_item, parent, false);
            TaskItemHolder vh = new TaskItemHolder(itemView, itemBindingContext, OnClick);
            return vh;
        }

        private void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }


}