using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController :
    MonoBehaviour
{

    public Player player;
    public GameObject enemyPrefab;
    public float enemySpawnDistance = 25f;

    public float enemyInterval = 4.0f;
    public float minimumEnemyInterval = 2f;
    public float enemyIntervalDecrement = 0.1f;

    private float gameTimer = 0f;
    private float enemyTimer = 0f;

    public TextMesh infoText;

    private float resetTimer = 3f;
    private float gameTime = 15f;
    private bool gameEnd = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.health > 0 && gameTimer <= gameTime)
        {
            //infoText.text = "Health: " + player.health;
            infoText.text = "\nPoints: " + player.points;
            gameTimer += Time.deltaTime;
            //infoText.text += "\nTime: " + Mathf.Floor(gameTimer);
        }
        else
        {
            gameEnd = true;
            if (player.health <= 0)
            {
                infoText.text = "Game Over!";
                infoText.text += "\nYou survived for " + Mathf.Floor(gameTimer) + " seconds!";
                resetTimer -= Time.deltaTime;
               
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } else
            {
                infoText.text = "You Won!!";
                infoText.text = "You earned " + player.points + "points!";
                    SceneManager.LoadScene("HappyEndGame");
            }
        }

       
            enemyTimer -= Time.deltaTime;
            if (enemyTimer <= 0)
            {
                enemyTimer = enemyInterval;
                enemyInterval -= enemyIntervalDecrement;


                if (enemyInterval < minimumEnemyInterval)
                {
                    enemyInterval = minimumEnemyInterval;
                }

                GameObject enemyObject = Instantiate(enemyPrefab);

                Enemy enemy = enemyObject.GetComponent<Enemy>();

                float randomAngle = Random.Range(0f, Mathf.PI * 2f);
                enemy.transform.position = new Vector3(
                    player.transform.position.x + Mathf.Cos(randomAngle) * enemySpawnDistance,
                    enemy.transform.position.y,
                    player.transform.position.z + Mathf.Sin(randomAngle) * enemySpawnDistance
                 );

                enemy.player = player;
                enemy.direction = (player.transform.position - enemy.transform.position).normalized;
                enemy.transform.LookAt(player.transform);
            }
        
    }
}
