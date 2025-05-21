using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace SojaExiles
{
    public class ClosetopencloseDoor : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
    {
        public Animator Closetopenandclose;
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

            // Optional: Add highlight effect
            // GetComponent<Renderer>().material.color = Color.yellow;
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
            hoverInteractor = null;

            // Optional: Remove highlight effect
            // GetComponent<Renderer>().material.color = Color.white;
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 15)
                {
                    ToggleDoorState(args.interactorObject);
                }
            }
        }

        private void ToggleDoorState(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor interactor)
        {
            if (open)
            {
                StartCoroutine(CloseDoor(interactor));
            }
            else
            {
                StartCoroutine(OpenDoor(interactor));
            }
        }

        IEnumerator OpenDoor(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor interactor)
        {
            print("you are opening the closet door");
            Closetopenandclose.Play("ClosetOpening");
            open = true;

            SendHaptic(interactor, 0.5f, 0.1f);

            yield return new WaitForSeconds(.5f);
        }

        IEnumerator CloseDoor(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor interactor)
        {
            print("you are closing the closet door");
            Closetopenandclose.Play("ClosetClosing");
            open = false;

            SendHaptic(interactor, 0.3f, 0.1f);

            yield return new WaitForSeconds(.5f);
        }

        private void SendHaptic(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor interactor, float amplitude, float duration)
        {
            if (interactor is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor controllerInteractor &&
                controllerInteractor.xrController != null)
            {
                controllerInteractor.xrController.SendHapticImpulse(amplitude, duration);
            }
        }
    }
}
