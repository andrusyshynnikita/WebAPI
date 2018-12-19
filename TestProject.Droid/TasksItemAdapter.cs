//using Android.Support.V7.Widget;
//using Android.Views;
//using System;
//using MvvmCross.Droid.Support.V7.AppCompat.Widget;
//using Android.Support.V7.RecyclerView;
//using MvvmCross.Droid.Support.V7.RecyclerView;
//using TestProject.Core.Models;
//using MvvmCross.ViewModels;
//using Android.Widget;

//namespace testproject.droid
//{
//    class TasksItemAdapter : MvxRecyclerView.Adapter
//    {
//        public MvxObservableCollection<TaskInfo> taskitem;

//        public TasksItemAdapter(MvxObservableCollection<TaskInfo> tasks)
//        {
//            taskitem = tasks;
//        }

//        public override int ItemCount
//        {
//            get {  return taskitem}
//        }

//        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
//        {
//            throw new NotImplementedException();
//        }

//    }

//    public class TaskItemHolder: RecyclerView.ViewHolder
//    {
//        public TextView TaskName { get; set; }
//        public TextView TaskStatus { get; set; }

//        public TaskItemHolder(View itemview): base(itemview)
//        {
//            TaskName =itemview.FindViewById<TextView>(Resource.Id.textview)
//        }
//    }
//}