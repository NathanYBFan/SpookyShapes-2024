using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        stateMachine.ChangeState(stateMachine.fightingState);
        ResetFocusOnInputField();
    }

    public void GameLoop()
    {

        // timer ticks down
        // on timer == 0 enemy will attack;
        // repeat
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

    public void StartGame()
    {
        stateMachine.ChangeState(stateMachine.addSpellState);
    }

    public void StartFight(GameObject fightBox)
    {
        List<GameObject> enemies = new List<GameObject>();
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
}
