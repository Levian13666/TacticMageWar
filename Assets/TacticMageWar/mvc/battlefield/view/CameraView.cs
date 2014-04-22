using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace mvc.battlefield {

    //TODO : add comments. Make better camera rotation.
    class CameraView : View {

        public float distance = 15.0f;
        public float zoomStep = 1.0f;
        public float moveStep = 0.2f;

        public float xSpeed = 250.0f;
        public float ySpeed = 120.0f;

        public float yMinLimit = -20;
        public float yMaxLimit = 80;

        private float x = 0.0f;
        private float y = 0.0f;
        private Transform target;

        protected override void Start() {
 	        name = "MainCamera";
            gameObject.AddComponent<Camera>();
            camera.nearClipPlane = 0.3f;
            camera.farClipPlane = 1000;
            camera.fieldOfView = 60;

            target = new GameObject().transform;

            var angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;

            // Make the rigid body not change rotation
            if (rigidbody) {
                rigidbody.freezeRotation = true;
            }

            transform.rotation = Quaternion.Euler(y, x, 0);
            transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
        }

        void LateUpdate() {
            if (Input.GetButton("CameraRotation")) {
                x += Input.GetAxis("MouseX") * xSpeed * Time.deltaTime;
                y -= Input.GetAxis("MouseY") * ySpeed * Time.deltaTime;

                y = ClampAngle(y, yMinLimit, yMaxLimit);

                transform.rotation = Quaternion.Euler(y, x, 0);
                target.transform.rotation = Quaternion.Euler(0, x, 0);
                transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
            }
            if (Input.GetAxis("MouseScrollWheel") > 0) {
                distance -= zoomStep;
                transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
            }
            if (Input.GetAxis("MouseScrollWheel") < 0) {
                distance += zoomStep;
                transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
            }
            if (Input.GetButton("MoveRight")) {
                target.transform.Translate(new Vector3(moveStep, 0, 0));
                transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
            }
            if (Input.GetButton("MoveLeft")) {
                target.transform.Translate(new Vector3(-moveStep, 0, 0));
                transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
            }
            if (Input.GetButton("MoveUp")) {
                target.transform.Translate(new Vector3(0, 0, moveStep));
                transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
            }
            if (Input.GetButton("MoveDown")) {
                target.transform.Translate(new Vector3(0, 0, -moveStep));
                transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
            }
        }

        static float ClampAngle(float angle, float min, float max) {
            if (angle < -360) {
                angle += 360;
            }
            if (angle > 360) {
                angle -= 360;
            }
            return Mathf.Clamp(angle, min, max);
        }

    }

}
