using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

namespace mvc.battlefield {

    public class PlayerControlCommand : Command {
        
        [Inject]
        public IPlayer player {get; set;}

        public override void Execute() {
            
        }

    }

}
