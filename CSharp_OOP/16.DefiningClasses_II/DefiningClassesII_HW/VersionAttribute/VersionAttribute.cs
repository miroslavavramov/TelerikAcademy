using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Method |AttributeTargets.Class
    | AttributeTargets.Interface | AttributeTargets.Enum, AllowMultiple = false)]
class VersionAttribute : Attribute
{
    public int Major { get; private set; }
    public int Minor { get; private set; }

    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }
}

