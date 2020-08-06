using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    [SerializeField] private int widthInUnityLenght = 16;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    void Update()
    {
        PaddleMoving();
    }

    private void PaddleMoving()
    {
        var paddlePos = Input.mousePosition.x / Screen.width * widthInUnityLenght;
        paddlePos = Mathf.Clamp(paddlePos, minX, maxX);
        transform.position = new Vector2(paddlePos, 0.4f);
    }
}
