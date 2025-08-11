//using UnityEngine;
//using UnityEngine.UI;

//public class SettingUI : MonoBehaviour
//{
//    public Slider playerFireRateSlider;
//    public Slider playerSpeedSlider;
//    public Slider playerLivesSlider;
//    public Slider playerBulletSpeedSlider;
//    public Slider enemyFireRateSlider;
//    public Slider enemySpeedSlider;
//    public Slider enemyBulletSpeedSlider;
//    public Slider enemySpawnSlider;
//    public Slider damageToBossSlider;
//    public Slider bossSpeedSlider;

//    public SettingsManager settingsManager;



//    private void Start()
//    {
//        playerBulletSpeedSlider.value = GameSettings.instance.playerBulletSpeed;
//        playerFireRateSlider.value = GameSettings.instance.playerFireRate;
//        playerSpeedSlider.value = GameSettings.instance.playerSpeed;
//        playerLivesSlider.value = GameSettings.instance.playerLives;
//        enemyFireRateSlider.value = GameSettings.instance.enemyFireRate;
//        enemySpeedSlider.value = GameSettings.instance.enemySpeed;
//        enemyBulletSpeedSlider.value = GameSettings.instance.enemyBulletSpeed;
//        enemySpawnSlider.value = GameSettings.instance.enemySpawn;
//        damageToBossSlider.value = GameSettings.instance.damageToBoss;
//        bossSpeedSlider.value = GameSettings.instance.bossSpeed;
//    }

//    public void UpdatePlayerFireRate(float value)
//    {
//        GameSettings.instance.playerFireRate = value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdatePlayerSpeed(float value)
//    {
//        GameSettings.instance.playerSpeed = value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdatePlayerLives(float value)
//    {
//        GameSettings.instance.playerLives = (int)value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdatePlayerBulletSpeed(float value)
//    {
//        GameSettings.instance.playerBulletSpeed = value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdateEnemyFireRate(float value)
//    {
//        GameSettings.instance.enemyFireRate = value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdateEnemySpeed(float value)
//    {
//        GameSettings.instance.enemySpeed = value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdateEnemyBulletSpeed(float value)
//    {
//        GameSettings.instance.enemyBulletSpeed = value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdateEnemySpawn(float value)
//    {
//        GameSettings.instance.enemySpawn = (int)value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdateDamageToBoss(float value)
//    {
//        GameSettings.instance.damageToBoss = value;
//        settingsManager.SaveSettings();
//    }

//    public void UpdateBossSpeed(float value)
//    {
//        GameSettings.instance.bossSpeed = value;
//        settingsManager.SaveSettings();
//    }

//    //public void ResetSettings()
//    //{
//    //    settingsManager.settingData = new GameSettings();
//    //    settingsManager.SaveSettings();
//    //    Start(); // Reinitialize sliders with default values
//    //}
//}
