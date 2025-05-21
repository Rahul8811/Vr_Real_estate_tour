using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace SojaExiles
{
    public class opencloseWindowApt : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
    {
        public Animator openandclosewindow;
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
                        StartCoroutine(OpenWindow());
                    }
                    else
                    {
                        StartCoroutine(CloseWindow());
                    }
                }
            }
        }

        IEnumerator OpenWindow()
        {
            print("you are opening the window");
            openandclosewindow.Play("Openingwindow");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator CloseWindow()
        {
            print("you are closing the window");
            openandclosewindow.Play("Closingwindow");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}