using Assets.TestArea.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DodgeTimer : MonoBehaviour
{
    public Text dodgeTimerText;
    private PlayerMovement _playerMovement;
    private double _seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDodgeTimer();
    }

    private void UpdateDodgeTimer()
    {
        if (_playerMovement != null && _playerMovement.TotalMilisecondsToWaitForAnotherDodge > 0)
        {
            _seconds = _playerMovement.TotalMilisecondsToWaitForAnotherDodge / 1000;
            dodgeTimerText.text = $"{_seconds:0.00}";
            dodgeTimerText.enabled = true;
        }
        else
        {
            dodgeTimerText.enabled = false;
        }
    }
}
