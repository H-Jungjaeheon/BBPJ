using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Player : Entity
{
    [SerializeField] private float moveSpeed = 5;

    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        InputFunc();

    }
    private void InputFunc()
    {
        Move();
        MouseInput();
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPos = transform.position;
            var vec = new Vector2(mousePos.x - targetPos.x, mousePos.y - targetPos.y).normalized;

            Debug.Log(vec);
            FindObjectOfType<Ball>().StrikeFunc(vec);
        }


    }
    //상하좌우 이동
    private void Move()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        Vector2 pos = new Vector2(hor, ver);
        Move(pos);
    }
    private void Move(Vector2 pos)
    {
        var dir = pos * moveSpeed * Time.deltaTime;
        rigid.AddForce(dir, ForceMode2D.Force);
    }
}
