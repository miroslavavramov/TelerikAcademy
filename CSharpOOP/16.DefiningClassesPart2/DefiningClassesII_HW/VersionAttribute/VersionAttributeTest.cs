using System;

[Version(1,1)]
class VersionAttributeTest
{
    static void Main()
    {
        Type type = typeof(VersionAttributeTest);

        object[] versionAttributes = type.GetCustomAttributes(false);

        foreach (VersionAttribute versionAttribute in versionAttributes)
        {
            Console.WriteLine("Current Version: " + versionAttribute.Major + "." + versionAttribute.Minor);
        }
    }
}

