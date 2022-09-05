using UnityEngine;

public class DialogSkipOperator : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DialogOperator.NextInput();
        }
    }
}
