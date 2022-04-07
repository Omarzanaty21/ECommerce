using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewModels
{
    public class AdminViewModel : UserBaseViewModel
    {
        public bool RememberMe { get; set; } = false;
        public string ReturnUrl { get; set; }
    }
}