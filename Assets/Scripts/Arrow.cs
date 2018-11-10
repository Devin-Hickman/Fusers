using UnityEngine;
using Unity;

namespace Fusers
{
    public class Arrow : MonoBehaviour
    {
        public float speed;
        public Vector3 direction;
        public Vector3 startPos;
        public Vector3 endPos;
        Rigidbody2D rb2d;

        void Update()
        {
            direction = endPos - startPos;
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity = speed * direction;
            if (Vector3.Distance(transform.position, startPos) > Vector3.Distance(endPos, startPos))
            {
                Destroy(this.gameObject);
            }
        }

        public void FireProjetile(Vector3 _endPos, Vector3 _startPos)
        {
            startPos = _startPos;
            endPos = _endPos;



        }
    }
}
