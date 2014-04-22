using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace mvc.battlefield {

    class Player : IPlayer {

        private Color color;

        public Color Color {
            get { return color; }
            set { color = value; }
        }

    }

}
