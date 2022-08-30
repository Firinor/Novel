using UnityEngine;

public class SinglBehaviour<T> : MonoBehaviour
{
    public static T instance;

    public void SingletoneCheck(T instance)
    {
        if (SinglBehaviour<T>.instance != null)
        {
            //Debug.LogError(typeof(T).ToString());
            Destroy(gameObject);
            return;
        }

        SinglBehaviour<T>.instance = instance;
    }
}