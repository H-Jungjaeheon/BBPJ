using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Player : Entity
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float strikeRange = 2;
    [SerializeField] private float angleRange = 50;
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
            TryStrke(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        }
    }
    #region StrikeFunc
    private void TryStrke(Vector3 dir)
    {
        Debug.DrawRay(transform.position, dir, Color.green);
        int layerMask = 1 << LayerMask.NameToLayer("Ball");
        var objs = Physics2D.CircleCastAll(transform.position, strikeRange, Vector2.zero, strikeRange, layerMask);

        foreach (var target in objs)
        {
            Vector3 interV = target.collider.transform.position - transform.position;
            var vec = new Vector2(dir.x, dir.y).normalized;

            // 'Ÿ��-�� ����'�� '�� ���� ����'�� ����
            float dot = Vector3.Dot(interV.normalized, vec);
            // �� ���� ��� ���� �����̹Ƿ� ���� ����� cos�� ���� ���ؼ� theta�� ����
            float theta = Mathf.Acos(dot);

            float degree = Mathf.Rad2Deg * theta;
            if (degree <= angleRange / 2f)
            {
                target.collider.gameObject.GetComponent<Ball>().StrikeFunc(vec);
            }
        }


        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 targetPos = transform.position;
        //var vec = new Vector2(mousePos.x - targetPos.x, mousePos.y - targetPos.y).normalized;

        //Debug.Log(vec);
        //FindObjectOfType<Ball>().StrikeFunc(vec);
    }
    private void OnDrawGizmos()
    {
        // DrawSolidArc(������, ��ֺ���(��������), �׷��� ���� ����, ����, ������)
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, strikeRange / 2, 2);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -strikeRange / 2, 2);
    }
    #endregion
    //�����¿� �̵�
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
