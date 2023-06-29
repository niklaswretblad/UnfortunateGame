using System;

namespace TextDisplayStates {
    public enum Door
    {
        Nothing,
        PressToOpenText,
        NeedKeyText,
        OpenedText,
        ElectricityNeededText
    }

    enum SearchableItem
    {
        Nothing,
        SearchText,
        NothingFoundText,
        FoundText
    }

    enum ElectricSwitch
    {
        Nothing,
        TurnOnElectricityText,
        TurnedOnElectricityText
    }
}
