
namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PurpleControl : VRTK_InteractableObject
    {
		PurpleButton pb;
       
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
				pb.LeftTrigger ();
            }
            else if (actualHand == (SDK_BaseController.ControllerHand.Right))
            {
				pb.RightTrigger ();
            }
        }

        protected void Start()
        {
			pb = GetComponent<PurpleButton>();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}