using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    // lives
    public int maxLives;


    public int speed;
    public int maxSpeed;
    public int upSpeed;
    public int deathImpulse;
    public Vector3 playerStartingPosition;


    public float enemyPatrolTime;
    public float enemyMaxOffset;
    public int attackCount;
    public bool dialogueMode;
}
