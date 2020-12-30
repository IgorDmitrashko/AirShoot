using UnityEngine;

public class SpownBlock : MonoBehaviour
{
    public GameObject[] _blocks;
    private Vector3 _spownPossition;
    void Awake() {
        SpownBlocks();
    }

    public void SpownBlocks() {
        _spownPossition.x = 1.5f;
        _spownPossition.y = 0.25f;
        _spownPossition.z = 15f;

        foreach(var item in _blocks)
        {
            Instantiate(item, _spownPossition, Quaternion.identity);
            _spownPossition.x += 3.5f;
        }
        _spownPossition.x = 1.5f;
    }
}
