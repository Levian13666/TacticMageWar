using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvc.battlefield 
{
    
    class PlayerControlMediator : Mediator 
    {

        [Inject]
        private PlayerControlSignal signal { get; set; }



    }

}
