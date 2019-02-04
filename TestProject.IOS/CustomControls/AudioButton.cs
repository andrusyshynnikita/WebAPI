using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TestProject.IOS.CustomControls
{
    [Register("AudioButton"), DesignTimeVisible(true)]
    public  class AudioButton : UIButton
    {
        private bool _checked;

        public AudioButton(IntPtr handle) : base(handle) { }

        public AudioButton()
        {
            Initialize();
            
        }

        private void Initialize()
        {
            Checked = false;
        }

        public override bool TouchInside
        {
            get
            {
                if (Checked == true)
                {
                    Checked = false;
                }
                else
                {
                    Checked = true;
                }

                return base.TouchInside;
            }
        }

        [Export("Checked"), Browsable(true)]
        public bool Checked
        {
            get
            {
                return _checked;
            }

            set
            {
                _checked = value;
            }
        }
    }
}