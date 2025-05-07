using System.Collections;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;

        public GameObject particlePlayerMove;
        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if(UiGameManager.Instance.isGameWin == false && UiGameManager.Instance.isGameOver == false)
            {
                if (Input.GetMouseButton(0))
                {
                    if (pathCreator != null)
                    {
                        distanceTravelled += speed * Time.deltaTime;
                        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

                        if (particlePlayerMove.active == false)
                        {
                            particlePlayerMove.SetActive(true);    
                        }
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (particlePlayerMove.active)
                {
                    StartCoroutine(deplayTime());
                }
            }


            if (UiGameManager.Instance.isGameWin == true)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

                speed = 5;
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        public IEnumerator deplayTime()
        {
            yield return new WaitForSeconds(0.1f);
            particlePlayerMove.SetActive(false);
        }
    }

   
}