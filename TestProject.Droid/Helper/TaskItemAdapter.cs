using Android.Support.V7.Widget;
using Android.Views;
using System;
using MvvmCross.Droid.Support.V7.RecyclerView;
using TestProject.Droid;
using Resource = TestProject.Droid.Resource;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace testproject.droid
{
    public class TasksItemAdapter : MvxRecyclerAdapter
    {
        // private MvxObservableCollection<TaskInfo> _taskcollection;
        public TasksItemAdapter(IMvxAndroidBindingContext bindingContext)
            : base(bindingContext)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.task_item, parent, false);
            return new TaskItemHolder(itemView, itemBindingContext) { Click=ItemClick }; 
        }
        
    }


}