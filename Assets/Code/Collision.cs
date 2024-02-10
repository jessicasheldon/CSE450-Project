using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class Collision : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision.gameObject);
        }
        //// Start is called before the first frame update
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
}
