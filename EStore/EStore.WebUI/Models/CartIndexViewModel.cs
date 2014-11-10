using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EStore.Domain.Entities;

namespace EStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}