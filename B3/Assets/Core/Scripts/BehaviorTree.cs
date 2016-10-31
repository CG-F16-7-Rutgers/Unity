using UnityEngine;
using System.Collections;
using TreeSharpPlus;
using System;
namespace RootMotion.FinalIK.Demos
{
    public class BehaviorTree : MonoBehaviour
    {
        public Transform police_wander1, police_wander2, police_wander3, police_wander4, police_wander5, spot, spot2;
        public GameObject police, police2, police3, person;
        public InteractionObject locker, ball, keys;
        private BehaviorAgent behaviorAgent;
        public GameObject door, escape_transform;
        private ArrayList policeList = new ArrayList();
        private ArrayList roamList = new ArrayList();
        private Node trigger_open_door;
        // Use this for initialization
        void Start()
        {
            door.GetComponent<AutoMoving>().enabled = false;
            escape_transform.GetComponent<ClickToMove>().enabled = false;
            policeList.Add(police);
            policeList.Add(police2);
            policeList.Add(police3);
            roam_gen();
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
        }

        // Update is called once per frame
        void Update()
        {

        }
        protected void roam_gen()
        {
            roamList.Add(new DecoratorLoop(
                new SequenceShuffle(
                    this.ST_ApproachAndWait(this.police_wander1, (GameObject)policeList[0]),
                    this.ST_ApproachAndWait(this.police_wander2, (GameObject)policeList[0]),
                    this.ST_ApproachAndWait(this.police_wander3, (GameObject)policeList[0])
                    ))
            );
            roamList.Add(new DecoratorLoop(
                new SequenceShuffle(
                    this.ST_ApproachAndWait(this.police_wander4, (GameObject)policeList[1]),
                    this.ST_ApproachAndWait(this.police_wander5, (GameObject)policeList[1])
                    ))
            );
            roamList.Add(new DecoratorLoop(
                new SequenceShuffle(
                    this.ST_ApproachAndWait(this.police_wander4, (GameObject)policeList[2]),
                    this.ST_ApproachAndWait(this.police_wander5, (GameObject)policeList[2])
                    ))
            );
        }
        protected float distance()
        {
            float dis = float.MaxValue;
            for (int i = 0; i < policeList.Count; i++)
            {
                float tmp = Math.Abs(((GameObject)policeList[i]).transform.position.z - this.person.transform.position.z) + Math.Abs(((GameObject)policeList[i]).transform.position.x - this.person.transform.position.x);
                dis = Math.Min(dis, tmp);
            }
            return dis;
        }
        protected Node ST_Pick_sth_up(GameObject participant)
        {
            return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("PICKUPRIGHT", true), new LeafWait(1000));
        }
        protected Node ST_ApproachAndWait(Transform target, GameObject participant)
        {
            Val<Vector3> position = Val.V(() => target.position);
            return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(10));
        }
        protected Node ST_interaction(GameObject participant, InteractionObject obj)
        {
            return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_StartInteraction(FullBodyBipedEffector.LeftHand, obj), new LeafWait(10));
        }
        protected Node BuildTreeRoot()
        {
            Func<bool> caught = () => {
                float dis = float.MaxValue;
                for (int i = 0; i < policeList.Count; i++)
                {
                    float tmp = Math.Abs(((GameObject)policeList[i]).transform.position.z - this.person.transform.position.z) + Math.Abs(((GameObject)policeList[i]).transform.position.x - this.person.transform.position.x);
                    dis = Math.Min(dis, tmp);
                }
                return dis < 20;
            };
            Node pick_up = new Sequence(
                this.ST_ApproachAndWait(keys.transform, this.person),
                this.ST_Pick_sth_up(this.person)
                );
            Node open = new Sequence(
                this.ST_ApproachAndWait(spot, this.person),
                this.ST_interaction(this.person, locker)
                );
            Func<RunStatus> opened_door = () => {
                door.GetComponent<AutoMoving>().enabled = true;
                return RunStatus.Success;
            };
            trigger_open_door = new Sequence(new LeafInvoke(opened_door), new LeafWait(1000));
            Node touch_ball = new Sequence(
                this.ST_ApproachAndWait(spot2, this.person),
                this.ST_interaction(this.person, ball)
                );
            Node duck = new Sequence(person.GetComponent<BehaviorMecanim>().Node_BodyAnimation("DUCK", true), new LeafWait(1000));
            Node end = new DecoratorForceStatus( RunStatus.Success, new SequenceParallel(new DecoratorLoop( new LeafAssert(caught)), duck));
            Func<RunStatus> escape_func = () => {
                person.GetComponent<UnitySteeringController>().minSpeed = 5.0f;
                person.GetComponent<UnitySteeringController>().maxSpeed = 7.0f;
                escape_transform.GetComponent<ClickToMove>().enabled = true;
                return RunStatus.Success;
            };
            Func<RunStatus> chase = () =>
            {
                for (int i = 0; i < policeList.Count; i++)
                {
                    ((GameObject)policeList[i]).GetComponent<UnitySteeringController>().minSpeed = 5.0f;
                    ((GameObject)policeList[i]).GetComponent<UnitySteeringController>().maxSpeed = 7.0f;
                }
                return RunStatus.Success;
            };
            Node escape = new DecoratorLoop(new SequenceParallel(ST_ApproachAndWait(escape_transform.transform, person), new LeafInvoke(escape_func)));
            Node story = new Sequence(
                pick_up,
                open,
                trigger_open_door,
                touch_ball,
                new SequenceParallel(
                    escape,
                    new LeafInvoke(chase),
                    new DecoratorLoop(
                        new SequenceParallel(ST_ApproachAndWait(person.transform, (GameObject)policeList[0]),
                            ST_ApproachAndWait(person.transform, (GameObject)policeList[1]),
                            ST_ApproachAndWait(person.transform, (GameObject)policeList[2]))
                        ),
                    end
                    )
                );
            Node root = new Sequence ( new SequenceParallel(
                 (Node)roamList[0], (Node)roamList[1], (Node)roamList[2], story 
            ));
            return root;
        }
    }
}