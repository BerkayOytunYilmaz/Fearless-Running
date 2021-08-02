using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForwardMoment : MonoBehaviour
{
    public float hiz;

    public float hiz2;
    Rigidbody rb;
    Vector3 worldPosition;
    int coins;
    bool stop;
    public GameObject text;
    public GameObject panel1;
    public GameObject panel2;
    public TextMeshProUGUI skortext;
    public GameObject yenidendene;
    public float zaman ;
    public GameObject[] parts;
    public float distance;
    public float sure1 = 0f;
    bool zemindeyim = false;
    public float cikis;
    public float giris;
    public bool jump = false;
    public AudioSource arkafon;




    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stop = true;
        panel2.SetActive(false);
        yenidendene.SetActive(false);
        hiz2 = 500f;
        distance = 160;
        
        
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
          hiz2 +=  (8*Time.deltaTime);
          //Debug.Log(hiz2);
            skortext.text = "SKOR = " + coins;




        
        if (Input.GetMouseButton(0))
        {
            stop = false;
            Destroy(text);
            Destroy(panel1);

            if (worldPosition.x < transform.position.x + 4.75f)
            {
                hiz = -7f;
                //Debug.Log("-5");
            }

            else if (worldPosition.x < transform.position.x + 7.75f)
            {
                hiz = -3.5f;
                //Debug.Log("-2.5");
            }

            else if (worldPosition.x < transform.position.x + 8.35f)
            {
                hiz = -2.5f;
                //Debug.Log("-1.5");
            }

            else if (worldPosition.x < transform.position.x + 10.35f)
            {
                hiz = 0f;
                //Debug.Log("0");
            }

            else if (worldPosition.x < transform.position.x + 11.35f)
            {
                hiz = 2.5f;
                //Debug.Log("+1.5");

            }

            else if (worldPosition.x < transform.position.x + 12.35f)
            {
                hiz = 3.5f;
                //Debug.Log("+2.5");

            }

            else if (worldPosition.x < transform.position.x + 14.25f)
            {
                hiz = 7f;
                //Debug.Log("+5");
            }










        }
        else if(Input.GetMouseButtonUp(0)){

            hiz=0;
        }
        Vector3 mousePos = Input.mousePosition * 100f;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
 


        






        //Debug.Log(mousePos.y);
        //Debug.Log(worldPosition);
        //Debug.Log(worldPosition.y);
        //Debug.Log(transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space çalıştı");
            rb.AddForce(0, 300, 0);
        }

        if (zemindeyim==true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                hiz = 0f;
                cikis = mousePos.y;
                Debug.Log("cikis " + mousePos.y);
            }
            if (Input.GetMouseButtonDown(0))
            {
                giris = mousePos.y;
                Debug.Log("giris" + giris);
            }

            if (cikis-giris>=30000f )
         {
            

            
                rb.AddForce(0, 250, 0);
                cikis = 0f;
                jump = true;

                Debug.Log("zıplattım");
            }
       

        }

        
        



    }

    private void FixedUpdate()
    {

        if (stop == false)
        {
            MovementFunc();
        }

    }
    void MovementFunc()
    {

        rb.velocity = new Vector3(hiz, rb.velocity.y, hiz2 * Time.fixedDeltaTime);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Point")
        {
            int random =Random.Range(0,6);
            Instantiate(parts[random], new Vector3(0, 0,distance), Quaternion.identity);
            distance += 20f;

        }

        if (other.gameObject.tag == "coin")
        {
            
            
            Destroy(other.gameObject);
            coins++;
            //Debug.Log(coins);

            
        }

        if (other.gameObject.tag == "effect")
        {


                other.transform.GetChild(0).gameObject.SetActive(true);
                other.transform.GetChild(1).gameObject.SetActive(true);


        }
        if (other.gameObject.tag == "engel")
        {

            
            Destroy(arkafon);
            
                other.transform.GetChild(0).gameObject.SetActive(true);
                other.transform.GetChild(1).gameObject.SetActive(true);
            

            stop = true;
            hiz2 = 0f;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            //Debug.Log("fail");




            panel2.SetActive(true);
           
            yenidendene.SetActive(true);

            
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag=="zeminim")
        {
            zemindeyim = true;
            jump = false;
            //Debug.Log("zemindeyim");
         
        }
        
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "zeminim")
        {
            zemindeyim = false;
            //Debug.Log("zeminden çıktım");

        }
    }
}

