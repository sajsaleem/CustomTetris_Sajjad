using System;

[AttributeUsage(AttributeTargets.Field)]
public class QaDebugMode : Attribute
{
}

[AttributeUsage(AttributeTargets.Field)]
public class DevDebugMode : Attribute
{
}
