using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    //Khai bao vi tri con cuu
    Vector3 mousePos;
    //Khai bao toc doc cuu di chuyen
    public float moveSpeed = 5;
    //Khai bao toa do gioi han ma cuu co the di chuyen
    public float minX = -5.5f;
    public float maxX = 5.5f;
    public float minY = -3;
    public float maxY = 3;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        //Lay vi tri dau tien cua con cuu
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //Khi click chuot thi thay doi vi tri con cuu
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Gioi han pham vi ma cuu co the di chuyen
            mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), Mathf.Clamp(mousePos.y, minY, maxY), 0);
        }
        // Ham dich chuyen
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Neu bom va vao nguoi choi(con cuu) thi ket thuc game
        Destroy(other.gameObject);
        gameController.GetComponent<GameController>().EndGame();
    }
}
