using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Product.Components.Models
{
    public class DispatchModel
    {
        public bool IsEditable { get; set; }

        public string ControlToLoad { get; set; }

        public bool InProfileMode { get; set; }

    }
}