using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonBase<GameManager>
{
    // Public static variables
    public static GameStateMachine stateMachine = new GameStateMachine();

    #region Getters & Setters
    public SpellNameLimiterBase SelectedLimiter { get => selectedLimiter; set => selectedLimiter = value; }
    public GenericSpell SelectedSpell { get => selectedSpell; set => selectedSpell = value; }

    public int SpellDamageMultiplier { get => spellDamageMultiplier; set => spellDamageMultiplier = value; }
    public InputActionAsset PlayerInputAction { get => playerInputAction; }
    public GameObject MainPlayer { get => mainPlayer; set => mainPlayer = value; }
    public GameObject SpellSpawnPosGO { get => spellSpawnPosGO; set => spellSpawnPosGO = value; }
    public GameObject[] SpellGOList { get => spellGOList; }
    public GameObject EnemyBase { get => enemyBase; }
    public List<GameObject> Enemies { get => enemies; }
    public List<BaseEnemy> CurrentEnemies { get => currentEnemies; set => currentEnemies = value; }
    #endregion

    #region Serialize Fields
    [SerializeField] private InputActionAsset playerInputAction;
    [SerializeField] private GameObject mainPlayer;
    [SerializeField] private TMP_InputField playerInputField;
    [SerializeField] private GameObject spellSpawnPosGO;
    [SerializeField] private GameObject[] spellGOList;
    [SerializeField] private GameObject enemyBase;
    [SerializeField] private EnemyData[] enemyTypes;
    [SerializeField, ReadOnly] private List<GameObject> enemies;
    [SerializeField] private List<BaseEnemy> currentEnemies;
    #endregion

    #region Private Variables
    // Selected elements
    private SpellNameLimiterBase selectedLimiter;
    private GenericSpell selectedSpell;
    // Damage multiplier
    private int spellDamageMultiplier = 1;
    #endregion

    private void Start()
    {
        playerInputField.onFocusSelectAll = true;
        stateMachine.ChangeState(stateMachine.menuState);
        ResetFocusOnInputField();
    }
    private void Update()
    {
        if (stateMachine.GetCurrentState() != stateMachine.addSpellState)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
                ResetFocusOnInputField();
        }
        GameLoop();
    }
    public void GameLoop()
    {
        if (stateMachine.GetCurrentState() == stateMachine.fightingState)
        {
            if (CheckFinishedFight())
            {
                stateMachine.ChangeState(stateMachine.travelState);
            }
            else
            {
                //ResetFocusOnInputField();
            }
        }
        // timer ticks down
    }

    public void ResetFocusOnInputField()
    {
        if (!playerInputField.isActiveAndEnabled)
        {
            playerInputField.enabled = true;
            playerInputField.gameObject.SetActive(true);
        }

        playerInputField.text = string.Empty;
        playerInputField.ActivateInputField();
        playerInputField.Select();
    }

    public void MenuSetup()
    {

    }

    public void GameOver()
    {

    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            yield return null;
            if (!LevelLoadManager.Instance.IsLoadingLevel) break;
        }
        stateMachine.ChangeState(stateMachine.addSpellState);
        LevelLoadManager.Instance.LoadMenuOverlay(LevelLoadManager.LevelNamesList[3]);
    }

    public void StartFight(GameObject fightBox)
    {
        ResetFocusOnInputField();
    }

    public void StartTravel()
    {

    }

    public void SpawnSpell(GenericSpell spellData)
    {
        GameObject spellObject = Instantiate(spellData.spellObject, spellSpawnPosGO.transform.position, Quaternion.identity);
        spellObject.GetComponent<ActiveSpell>().Initialize(spellData);
    }

    public BaseEnemy SpawnEnemy(Vector3 spawnPos)
    {
        GameObject enemy = Instantiate(enemyBase, spawnPos, Quaternion.identity);
        int enemyToPick = Random.Range(0, enemyTypes.Length);
        BaseEnemy bEnemy = enemy.GetComponent<BaseEnemy>();
        bEnemy.EnemyType = enemyTypes[enemyToPick];
        enemies.Add(enemy);
        return bEnemy;
        
    }

    public bool CheckFinishedFight()
    {
        if (currentEnemies.Count <= 0)
            return true;

        foreach (BaseEnemy enemy in currentEnemies)
            if (enemy != null && !enemy.IsDead) return false;

        currentEnemies.Clear();
        return true;
    }
}
