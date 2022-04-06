using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    bool canJump = true;
    /*
    private Transform theTransform;
    public Vector2 Xrange = Vector2.zero;
    public Vector2 Yrange = Vector2.zero;

    void LateUpdate(){
        theTransform.position = new Vector2(
            Mathf.Clamp(transform.position.x, Yrange.x, Yrange.y),
            //Mathf.Clamp(transform.position.y, Xrange.x, Xrange.y)
            //transform.position.z
        );
    } 
    */
    //---Start is called before the first frame update
    void Start()
    {
        //theTransform = GetComponent<Transform>();
    }

    //---Update is called once per frame
    void Update(){
        
        if (Input.GetKey("left")){
            //---------------------- Una unidad (pixel) equivale a un metro
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

         if (Input.GetKey("right")){
            //---------------------- Una unidad (pixel) equivale a un metro
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (!Input.GetKey("left") && (!Input.GetKey("right"))){
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }

        if (Input.GetKeyDown("up") && canJump){
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.tag == "ground"){
            canJump = true;
        }
    }
}
