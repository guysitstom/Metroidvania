using UnityEngine;

[CreateAssetMenu(fileName = "HasDash", menuName = "UnlockedDash")]
public class HasDash : ScriptableObject
{
    public bool hasDash = false;

    void OnEnable()
    {
        hasDash = false;
    }
}

