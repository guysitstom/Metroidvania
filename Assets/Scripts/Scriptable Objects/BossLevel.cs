using UnityEngine;

    [CreateAssetMenu(fileName = "BossLevel", menuName = "BossLevel?")]
public class BossLevel : ScriptableObject
{
    public bool isBossScene = false;

    void OnEnable()
    {
        isBossScene= false;
    }
}

