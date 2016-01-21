using AspMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.ViewModels
{
    public class ClientViewModel
    {
        public Client Client { get; set; }
        public int addressId { get; set; }

        public ClientViewModel() { }

        public ClientViewModel(Client Client, int addressId)
        {
            this.Client = Client;
            this.addressId = addressId;
        }
    }
}
