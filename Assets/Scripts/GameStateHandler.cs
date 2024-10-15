using UnityEngine;
using UnityEngine.UI;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Text totalMoneyLabel; //Refers to money label at upper left corner
    [SerializeField] private Text currentWaveLabel;
    [SerializeField] private Text playButtonLabel;
    
    private gameStatus currentState = gameStatus.play;
    private EnemySpawn enemySpawn;
    public AudioSource AudioSource { get; private set; }

    
    void Start()
    {
        playButton.gameObject.SetActive(false);
        AudioSource = GetComponent<AudioSource>();
        ShowMenu();
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }
    
    public void setCurrentGameState()
    {
        if (enemySpawn.TotalEscaped >= 10)
        {
            currentState = gameStatus.gameover;
        }
        else if (enemySpawn.WaveNumber == 0 && (enemySpawn.TotalKilled + enemySpawn.RoundEscaped) == 0)
        {
            currentState = gameStatus.play;
        }
        else if (enemySpawn.WaveNumber >= enemySpawn.TotalWaves)
        {
            currentState = gameStatus.win;
        }
        else
        {
            currentState = gameStatus.next;
        }
        ShowMenu();
    }
    
    public void playButtonPressed()
    {
        Debug.Log("Play Button Pressed");
        switch (currentState)
        {
            case gameStatus.next:
                enemySpawn.WaveNumber += 1;
                enemySpawn.TotalEnemies += waveNumber;
                break;
            default:
                totalEnemies = 3;
                totalEscaped = 0;
                TotalMoney = 10;
                TowerManager.Instance.DestroyAllTower();
                TowerManager.Instance.RenameTagsBuildSites();
                totalMoneyLabel.text = TotalMoney.ToString();
                waveNumber = 0;
                totalEscapedLabel.text = "Escaped " + totalEscaped + "/10";
                AudioSource.PlayOneShot(SoundManager.Instance.NewGame);
                break;
        }
        DestroyAllEnemies();
        TotalKilled = 0;
        RoundEscaped = 0;
        currentWaveLabel.text = "Wave " + (waveNumber + 1);
        StartCoroutine(Spawn());
        playButton.gameObject.SetActive(false);
    }
    
    private void ShowMenu()
    {
        switch (currentState)
        {
            case gameStatus.gameover:
                playButtonLabel.text = "Play Again!";
                AudioSource.PlayOneShot(SoundManager.Instance.Gameover);
                break;
            case gameStatus.next:
                playButtonLabel.text = "Next Wave";
                break;
            case gameStatus.play:
                playButtonLabel.text = "Play";
                break;
            case gameStatus.win:
                playButtonLabel.text = "Play";
                break;
        }

        playButton.gameObject.SetActive(true);
    }
    
    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TowerManager.Instance.disableDragSprite();
            TowerManager.Instance.towerButtonPressed = null;
        }
    }
}