
namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RedControl : VRTK_InteractableObject
    {
        RedCube rc;
       
        public override void StopUsing(VRTK_InteractUse previousUsingObejct)
        {
            base.StopUsing(previousUsingObejct);
        }

        public override void StartUsing(VRTK_InteractUse currentUsingObject)
        {
            base.StartUsing(currentUsingObject);
            SDK_BaseController.ControllerHand actualHand = VRTK_DeviceFinder.GetControllerHand(usingObject.gameObject);
            Debug.Log(actualHand.ToString());

            if (actualHand == (SDK_BaseController.ControllerHand.Left))
            {
                rc.LeftTrigger();
            }
            else if (actualHand == (SDK_BaseController.ControllerHand.Right))
            {
                rc.RightTrigger();
            }
        }

        protected void Start()
        {
            rc = GetComponent<RedCube>();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}