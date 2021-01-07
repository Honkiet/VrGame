using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Core
{
    public class LocomotionController : MonoBehaviour
    {
        public XRController leftRay;
        public XRController rightRay;
        public InputHelpers.Button UiActivationButton;
        public float activationThreshold = 0.1f;

        // Update is called once per frame
        void Update()
        {
            if (leftRay)
            {
                leftRay.gameObject.SetActive(CheckIfActivated(leftRay));
            }
            if (rightRay)
            {
                rightRay.gameObject.SetActive(CheckIfActivated(rightRay));
            }
        }

        public bool CheckIfActivated(XRController controller)
        {
            InputHelpers.IsPressed(controller.inputDevice, UiActivationButton, out bool isActivated, activationThreshold);
            return isActivated;
        }
    }

}
