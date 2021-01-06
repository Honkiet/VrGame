using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAreaBehaivior : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Transform area;
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget(target);
    }

    void MoveTowardsTarget(Transform target)
    {

        var offset = target.position.x - transform.position.x; // Is transform.position rght ?
        //Get the difference.
        if (offset > .1f) // as long as there is a diference greater than .1f do this
        {
            offset = 1 * speed;

            area.position += new Vector3(offset * Time.deltaTime,0,0) ;

        }

        else if (offset < -0.1f) // if x is negative
        {
            offset = -1 * speed;

            area.position += new Vector3(offset * Time.deltaTime, 0, 0);

        }
    }
}
