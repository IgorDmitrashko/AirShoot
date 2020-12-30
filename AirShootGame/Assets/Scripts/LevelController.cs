using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
   [SerializeField] public UnityEvent UpLevel;

    [SerializeField] private EnemyСharacteristics _enemyСharacteristics;    
    [SerializeField] private SpownBlock _spownBlock;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Ball _ball;

    private int _blockCount = 3;    

    void Start() {
        _ball.HitTheBlock += BlockDestroed;
    }

    public void BlockDestroed() {
        --_blockCount;
        if(_blockCount <= 0)
        {
            UpLvl();
        }
    }

    private void OnDestroy() {
        _enemyСharacteristics.moovementSpeed = _enemyСharacteristics._defoaltSpeedEnemy;
    }
    private void UpLvl() {
        _enemyСharacteristics.moovementSpeed += 1f;
        _enemy._speed = _enemyСharacteristics.moovementSpeed;
        _blockCount = 3;
        _spownBlock.SpownBlocks();
        UpLevel?.Invoke();
    }
}
