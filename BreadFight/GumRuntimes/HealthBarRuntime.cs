using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadFight.GumRuntimes
{
    public partial class HealthBarRuntime
    {




        partial void CustomInitialize () 
        {
        }


        public void OnUpdateUI(int value)
        {
            this.HP.Text = value.ToString();
        }

    }
}
