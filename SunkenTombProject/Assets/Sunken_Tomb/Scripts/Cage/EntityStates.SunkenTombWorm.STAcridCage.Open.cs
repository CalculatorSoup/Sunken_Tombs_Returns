using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using EntityStates;

namespace SunkenTombWorm.EntityStates.AcridCage
{
    public class Open : EntityState
    {
        public static float duration = 1f;
        private static int OpeningStateHash = Animator.StringToHash("Open");
        private static int OpeningParamHash = Animator.StringToHash("Open.playbackRate");
        // Start is called before the first frame update
        public override void OnEnter()
        {
            base.OnEnter();

            ChildLocator cl = gameObject.GetComponent<ChildLocator>();

            if (cl)
            {
                Transform cage = cl.FindChild("Cage");
                Transform door = cl.FindChild("Door");

                if (cage)
                {
                    var cageAnimator = cage.gameObject.GetComponent<Animator>();
                    if (cageAnimator)
                    {
                        PlayAnimationOnAnimator(cageAnimator, "Base", "Open");
                    }
                }
                if (door)
                {
                    door.gameObject.SetActive(false);
                }

            }

            //PlayAnimation("Base", OpeningStateHash, OpeningParamHash, duration);
        }

        // Update is called once per frame
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.fixedAge >= duration)
            {
                outer.SetNextState(new Closed());
            }
        }
    }
}