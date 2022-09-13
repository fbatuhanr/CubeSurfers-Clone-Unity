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
            Destroy(stack.GetComponent<BoxCollider>());
            stack.SetParent(null);
        }
    }
}
