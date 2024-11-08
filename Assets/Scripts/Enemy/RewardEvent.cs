using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "RewardEvent", menuName = "Events/RewardEvent")]
public class RewardEvent : ScriptableObject
{
    public UnityAction<int> OnRewarded;

    public void Raise(int amount)
    {
        if (OnRewarded != null)
        {
            OnRewarded.Invoke(amount);
        }
    }
}
