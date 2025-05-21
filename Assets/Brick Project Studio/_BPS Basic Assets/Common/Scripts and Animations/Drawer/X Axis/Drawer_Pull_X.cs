using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace SojaExiles
{
    public class Drawer_Pull_X : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
    {
        public Animator pull_01;
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
                if (dist < 10)
                {
                    if (open == false)
                    {
                        StartCoroutine(OpenDrawer());
                    }
                    else
                    {
                        StartCoroutine(CloseDrawer());
                    }
                }
            }
        }

        IEnumerator OpenDrawer()
        {
            print("you are opening the drawer");
            pull_01.Play("openpull_01");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator CloseDrawer()
        {
            print("you are closing the drawer");
            pull_01.Play("closepush_01");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}