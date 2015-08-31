using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIAUniversalApp.Controllers
{
    public class BaseController
    {
        public ActiveQuoteViewModel activeQuoteViewModel
        {
            get;
            set;
        }

        public void LogOut()
        {
            throw new System.NotImplementedException();
        }
    }
}
