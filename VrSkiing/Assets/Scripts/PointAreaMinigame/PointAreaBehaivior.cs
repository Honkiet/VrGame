using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PointArea
{
    public class PointAreaBehaivior : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        [SerializeField] Transform area;
        private float target = 5;

        // Update is called once per frame
        void Update()
        {
            MoveTowardsX(target);
        }

        void MoveTowardsX(float ptarget)
        {

            var offset = ptarget - transform.position.x; // Is transform.position right ?
                                                         //Get the difference.
            if (offset < .1f && offset > -0.1f)
            {// When target reached, pick a new target
                target = PickRandomX();
                return;
            }

            if (offset > .1)
            {
                offset = 1 * speed;

                area.position += new Vector3(offset * Time.deltaTime, 0, 0);

            }
            else // if x is negative
            {
                offset = -1 * speed;

                area.position += new Vector3(offset * Time.deltaTime, 0, 0);

            }

        }

        float PickRandomX()
        {
            float x = Random.Range(-1f, 9);
            return x;
        }

        void MakeAreaSmaller() //To Do: scale over time
        {
            // GetComponent<Transform>().localScale 
        }


    }
}
