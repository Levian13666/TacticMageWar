using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using UnityEngine;

namespace mvc.battlefield {

    class GameFieldService : IGameFieldService {

        //TODO : move all contans to configuration file
        public void InitField(GameObject contextView) {
            initMainCamera().transform.parent = contextView.transform;
        }

        private GameObject initMainCamera() {
            GameObject cameraGameObject = new GameObject();
            cameraGameObject.AddComponent<CameraView>();
            return cameraGameObject; 
        }

    }

}
