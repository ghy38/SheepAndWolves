using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 5;
    public float destroyTime = 2;
    public GameObject explor;
    // Start is called before the first frame update
    void Start()
    {
        //Thiet lap thoi gian huy bom
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Tinh toa do tu vi tri con soi den vi tri con cuu
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);
    }

    void OnDestroy()
    {
        //Thiet lap hieu ung no bom ngay tai vi tri qua bom sau khi qua bom bien mat mot khoang thoi gian la 0.5f
        GameObject exp =  Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
        Destroy(exp, 0.5f);
    }

}
