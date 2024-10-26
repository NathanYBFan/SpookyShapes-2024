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
    public GameObject MainPlayer { get => mainPlayer; }
    public GameObject SpellSpawnPosGO { get => spellSpawnPosGO; }
    public GameObject[] SpellGOList { get => spellGOList; }
    public GameObject EnemyBase { get => enemyBase; }
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
    #endregion

    #region Private Variables
    // Selected elements
    private SpellNameLimiterBase selectedLimiter;
    private GenericSpell selectedSpell;
    // Damage multiplier
    private int spellDamageMultiplier;
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
                ResetFocusOnInputField();
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
        enemies = new List<GameObject>();
        for (int i = 0; i < fightBox.transform.childCount; i++)
        {
            if (fightBox.transform.GetChild(i).name.CompareTo("Cube") == 0) continue;

            enemies.Add(fightBox.transform.GetChild(i).gameObject);
        }
    }

    public void StartTravel()
    {

    }

    public void SpawnSpell(GenericSpell spellData)
    {
        GameObject spellObject = Instantiate(spellData.spellObject, spellSpawnPosGO.transform.position, Quaternion.identity);
        spellObject.GetComponent<ActiveSpell>().Initialize(spellData);
    }

    public void SpawnEnemy(Vector3 spawnPos)
    {
        GameObject enemy = Instantiate(enemyBase, spawnPos, Quaternion.identity);
        int enemyToPick = Random.Range(0, enemyTypes.Length);
        enemy.GetComponent<BaseEnemy>().EnemyType = enemyTypes[enemyToPick];
    }

    public bool CheckFinishedFight()
    {
        if (enemies.Count <= 0)
            return true;

        foreach (GameObject enemy in enemies)
            if (enemy != null) return false;

        enemies.Clear();
        return true;
    }
}
