using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 topDownOffset;
    Vector3 driverSeatOffset;
    bool isTopDown = true;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // กำหนด offset สำหรับแต่ละมุมมอง (ปรับค่าได้ตามต้องการ)
        topDownOffset = new Vector3(0, 5, -8);         // มุมมองด้านบนหลังรถ
        driverSeatOffset = new Vector3(0, 1.2f, 0.5f); // มุมมองที่นั่งคนขับ
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isTopDown = !isTopDown;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (isTopDown)
        {
            transform.position = player.transform.position + topDownOffset;
            transform.LookAt(player.transform.position + Vector3.up * 1.5f);
        }
        else
        {
            transform.position = player.transform.TransformPoint(driverSeatOffset);
            transform.rotation = player.transform.rotation;
        }
    }
}