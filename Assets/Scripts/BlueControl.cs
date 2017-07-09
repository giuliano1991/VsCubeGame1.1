
namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BlueControl : VRTK_InteractableObject
    {
		BlueCube bc;
       
        public override void StopUsing(VRTK_InteractUse previousUsingObejct)
        {
            base.StopUsing(previousUsingObejct);
        }

        public override void StartUsing(VRTK_InteractUse currentUsingObject)
        {
            base.StartUsing(currentUsingObject);
			bc.BlueCubeTrigger ();
        }

        protected void Start()
        {
			bc = GetComponent<BlueCube>();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}