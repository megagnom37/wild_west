using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LanguageManager : MonoBehaviour {

    static Dictionary<string, ArrayList> langDict = new Dictionary<string, ArrayList>{
        { "t_single", new ArrayList { "SINGLEPLAYER", "ОДИНОЧНАЯ" } },
        { "t_multi", new ArrayList  { "MULTIPLAYER", "МУЛЬТИПЛЕЕР" } },
        { "t_settings", new ArrayList { "SETTINGS", "НАСТРОЙКИ" } },
        { "t_exit", new ArrayList { "EXIT", "ВЫХОД" } },
        { "t_shop", new ArrayList { "SHOP", "МАГАЗИН" } },

        { "t_result_title", new ArrayList { "RESULT", "РЕЗУЛЬТАТ" } },

        { "t_win", new ArrayList { "YOU WIN", "ВЫ ВЫИГРАЛИ" } },
        { "t_lose", new ArrayList { "YOU LOSE", "ВЫ ПРОИГРАЛИ" } },
        { "t_tie", new ArrayList { "YOU TIE", "НИЧЬЯ" } },
        { "t_failed", new ArrayList { "FAILED", "НЕУДАЧНО" } },
        { "t_wait", new ArrayList { "WAIT...", "ОЖИДАЙТЕ..." } },
        { "t_time", new ArrayList { "TIME: ", "ВРЕМЯ: " } },
  
        { "t_ready", new ArrayList { "READY ", "ПРИГОТОВИТЬСЯ " } },
        { "t_fire", new ArrayList { "FIREEEE ", "ОГОООНЬ " } },

        { "t_menu", new ArrayList { "MENU", "МЕНЮ" } },
        { "t_disconnect", new ArrayList { "LEAVE", "ВЫЙТИ" } },

        { "t_mode_title", new ArrayList { "SELECT MODE", "ВЫБЕРИТЕ РЕЖИМ" } },
        { "t_server", new ArrayList { "SERVER", "СЕРВЕР" } },
        { "t_client", new ArrayList { "CLIENT", "КЛИЕНТ" } },

        { "t_settings_title", new ArrayList { "SETTINGS", "НАСТРОЙКИ" } },
        { "t_version_about", new ArrayList { "VERSION", "ВЕРСИЯ" } },

        { "t_sound_off", new ArrayList { "SOUND OFF", "ЗВУК ВЫКЛ." } },
        { "t_sound_on", new ArrayList { "SOUND ON", "ЗВУК ВКЛ." } },
        { "t_language", new ArrayList { "ENGLISH", "РУССКИЙ" } },

        { "t_buy_title", new ArrayList { "BUY CLOTHES", "КУПИТЬ ОДЕЖДУ" } },
        { "t_cost", new ArrayList { "COST:", "ЦЕНА:" } },
        { "t_balance", new ArrayList { "BALANCE:", "БАЛАНС:" } },
        { "t_buy", new ArrayList { "BUY", "КУПИТЬ" } },

        { "t_restart", new ArrayList { "RESTART", "РЕСТАРТ" } },

        { "t_enemy_title", new ArrayList { "CHOOSE ENEMY", "ПРОТИВНИКИ" } },
        { "t_start", new ArrayList { "START", "СТАРТ" } },

        { "t_avrg_time", new ArrayList { "Avrg Shoot Time: ", "Среднее время выстрела: " } },
        { "t_reward", new ArrayList { "Reward: ", "Награда: " } },

        { "Bad Alex name", new ArrayList { "Bad Alex", "Плохой Алекс" } },
        { "Sheriff Ivan name", new ArrayList { "Sheriff Ivan", "Шериф Иван" } },
        { "Crazy Max name", new ArrayList { "Crazy Max", "Безумный Макс" } },

        { "Bad Alex descr", new ArrayList { "Rob children and old women. But will be able to shoot novice cowboy.",
            "Грабит детей и старух. Но сможет подстрелить новичка-ковбоя." } },
        { "Sheriff Ivan descr", new ArrayList { "Young sheriff. Every cowboy wants to shoot this bastard.",
            "Молодой шериф. Каждый ковбой хочет застрелить этого ублюдка." } },
        { "Crazy Max descr", new ArrayList { "The most terrible and fastest cowboy in Wild West.",
            "Самый страшный и быстрый ковбой на Диком Западе." } },

    };

    static public string Translate(string text)
    {
        int langIndex = PlayerPrefs.GetInt("language", 1);
        if (!langDict.ContainsKey(text))
            return "None";
        else
            return langDict[text][langIndex].ToString();
    }
}
