using TMPro;
using UnityEngine;

[RequireComponent(typeof(StickmenStorage))]
public class StickmenAmountShower : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _shower;
    [SerializeField] private TextMeshPro _amount;
    [SerializeField] private Vector3 _offset;

    private StickmenStorage _stickmenStorage;

    private void Awake()
    {
        _stickmenStorage = GetComponent<StickmenStorage>();
    }

    private void Update()
    {
        _amount.text = _stickmenStorage.StickmenCount.ToString();
    }

    public void SetAmountShowerPosition(Vector3 position)
    {
        Vector3 showerPosition = position;
        showerPosition += _offset;
        _shower.transform.position = showerPosition;
    }
}