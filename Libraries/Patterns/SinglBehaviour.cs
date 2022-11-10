using UnityEngine;

public class SinglBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public void SingletoneCheck(T instance)
    {
        if (SinglBehaviour<T>.instance != null)
        {
            if (SinglBehaviour<T>.instance.gameObject != null)
            {
                if (SinglBehaviour<T>.instance != instance)
                {
                    //Debug.Log($"{SinglBehaviour<T>.instance.GetType()}");
                    //Debug.Log($"{SinglBehaviour<T>.instance.GetHashCode()}");
                    //Debug.Log($"{instance.GetHashCode()}");
                    Destroy(gameObject);
                    return;
                }
            }
        }

        SinglBehaviour<T>.instance = instance;
    }
}