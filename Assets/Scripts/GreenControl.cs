
namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GreenControl : VRTK_InteractableObject
    {
		SpawnButton sb;
       
        public override void StopUsing(VRTK_InteractUse previousUsingObejct)
        {
            base.StopUsing(previousUsingObejct);
        }

        public override void StartUsing(VRTK_InteractUse currentUsingObject)
        {
            base.StartUsing(currentUsingObject);
			sb.SpawnButtonPress ();
        }

        protected void Start()
        {
			sb = GetComponent<SpawnButton>();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}