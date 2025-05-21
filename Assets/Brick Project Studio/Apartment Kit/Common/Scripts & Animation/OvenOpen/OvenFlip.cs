using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace SojaExiles
{
    public class OvenFlip : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
    {
        public Animator openandcloseoven;
        public bool open;
        public Transform Player;

        private UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor hoverInteractor;

        void Start()
        {
            open = false;
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);
            hoverInteractor = args.interactorObject as UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor;
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
            hoverInteractor = null;
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 15)
                {
                    if (open == false)
                    {
                        StartCoroutine(OpenOven());
                    }
                    else
                    {
                        StartCoroutine(CloseOven());
                    }
                }
            }
        }

        IEnumerator OpenOven()
        {
            print("you are opening the oven door");
            openandcloseoven.Play("OpenOven");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator CloseOven()
        {
            print("you are closing the oven door");
            openandcloseoven.Play("ClosingOven");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}