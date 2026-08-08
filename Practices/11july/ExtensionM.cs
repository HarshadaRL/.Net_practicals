using System;

public static class ExtensionM
{
    public static void ProperCase(this String name)
    {
        return char.ToUpper(name[0]) +
        name.Substring(1).ToLower();
    }
}