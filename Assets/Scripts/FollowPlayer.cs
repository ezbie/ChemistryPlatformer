using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;

    [SerializeField] private float xMax;
    [SerializeField] private float yMax;
    [SerializeField] private float xMin;
    [SerializeField] private float yMin;


    private void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(Player.position.x, xMin, xMax), Mathf.Clamp(Player.position.y, yMin, yMax), transform.position.z);
    }
}
