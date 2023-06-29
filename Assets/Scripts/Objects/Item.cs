using System;


public class Item
{
    private static int currentId = 0;

    private String name;
    private int id;    

    public Item(String name)
    {
        this.name = name;
        this.id = currentId;
        currentId += 1;
    }

    public void SetName(String name)
    {
        this.name = name;
    }

    public String GetName()
    {
        return name;
    }

    public int GetId()
    {
        return id;
    }
}
