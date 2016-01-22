using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.ViewModels.Account
{
    public class RoleViewModel
    {
        public string name{ get; set; }

        public RoleViewModel() { }

        public RoleViewModel(string name) { this.name = name; }
    }
}
