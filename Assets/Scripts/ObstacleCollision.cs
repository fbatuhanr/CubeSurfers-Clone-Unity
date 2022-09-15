using NaughtyAttributes;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [Tag] [SerializeField] private string stackTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(stackTag))
        {
            //Destroy(other.gameObject);

            var stack = other.transform;
            stack.SetParent(null);
            Destroy(stack.GetComponent<BoxCollider>());
        }
    }
}
