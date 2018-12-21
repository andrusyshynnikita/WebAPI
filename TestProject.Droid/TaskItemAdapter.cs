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

namespace testproject.droid
{
    public class TasksItemAdapter : MvxRecyclerView.Adapter
    {
        public MvxObservableCollection<TaskInfo> taskitem;

        public TasksItemAdapter(MvxObservableCollection<TaskInfo> tasks )
        {
            taskitem = tasks;
        }

        public override int ItemCount
        {
            get{ return taskitem.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TaskItemHolder vh = holder as TaskItemHolder;
            vh.TaskName.Text = taskitem[position].TaskName;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.task_item, parent, false);
            TaskItemHolder vh = new TaskItemHolder(itemView);
            return vh;
        }
    }


}