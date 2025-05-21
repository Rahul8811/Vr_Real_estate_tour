using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace SojaExiles
{
    public class opencloseDoor : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
    {
        public Animator openandclose;
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
                        StartCoroutine(opening());
                    }
                    else
                    {
                        StartCoroutine(closing());
                    }
                }
            }
        }

        IEnumerator opening()
        {
            print("you are opening the door");
            openandclose.Play("Opening");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("you are closing the door");
            openandclose.Play("Closing");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}