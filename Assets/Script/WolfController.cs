using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public GameObject boom;
    public float minBoomTime = 2;
    public float maxBoomTime = 4;
    private float boomTime = 0;
    private float lastBoomTime = 0;
    public float throughBoomTime = 0.5f;
    private GameObject Sheep;
    private Animator anim;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        UpdateBoomTime();
        //Tim vi tri cua nguoi choi
        Sheep = GameObject.FindGameObjectWithTag("Player");
        //Cai dat animation
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBoom", false);
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //Thiet lap animation khi nem bom
        if (Time.time >= lastBoomTime + boomTime - throughBoomTime)
        {
            anim.SetBool("isBoom", true);
        }
        // Neu nhu thoi gian hien tai lon hon tong thoi gian truoc do nem bom va
        // thoi gian gian cach giua moi lan nem bom thi tiep tuc nem bom
        if(Time.time >= lastBoomTime + boomTime) {
            ThroughBoom();
        }
    }

    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        //Thiet lap thoi gian nem bom cua soi
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    void ThroughBoom()
    {
       //Ham tao bom tai vi tri con soi
       GameObject bom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;

       //Lay toa do cua cuu
       bom.GetComponent<BoomController>().target = Sheep.transform.position;
        
        UpdateBoomTime();
        anim.SetBool("isBoom", false);
        //Moi qua bom duoc nem ra nguoi choi se tang duoc 1 diem den khi thua
        gameController.GetComponent<GameController>().GetPoint();
    }
}
