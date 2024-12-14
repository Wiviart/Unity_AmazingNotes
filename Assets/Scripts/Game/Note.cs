using UnityEngine;

public class Note : MonoBehaviour
{
    private float _speed = 0;

    public void Init(float speed)
    {
        _speed = speed;
    }

    private void LateUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime * _speed;
        
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
}