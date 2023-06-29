using System;

namespace DisplayTexts
{
    public class Door
    {        
        public const string PRESS_TO_OPEN_TEXT = "[Space] Open door";
        public const string OPENED_TEXT = "Opened door";
    }

    public class LockedDoor
    {
        public const string OPENED_WITH_KEY_TEXT = "Opened door using key";
        public const string COULD_NOT_OPEN_TEXT = "Could not open door. A key is needed!";
    }

    public class SearchableItem
    {
        public const string SEARCH_TEXT = "[SPACE] Search";
        public const string NOTHING_FOUND_TEXT = "Nothing was found!";
        public const string FOUND_TEXT = " was found!";
        public const string NOTHING_TEXT = "";
    }

    public class ElectricDoor
    {
        public const string ELECTRICITY_NEEDED_TEXT = "Seem to lack electricity. Maybe find a way to turn it on...";
    }

    public class ElectricSwitch
    {
        public const string TURN_ON_TEXT = "[SPACE] Turn on electricity";
        public const string TURNED_ON_TEXT = "Electricity was turned on!";
    }

    public class RestartGameScreen
    {
        public const string MESSAGE = "YOU DIED! Press [SPACE] to restart game";
    }
}

