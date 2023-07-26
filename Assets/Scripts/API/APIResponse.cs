using System.Collections.Generic;

[System.Serializable]
public class APIResult
{
    public EnemyDTO[] value { get; set; }
    public string[] formatters { get; set; }
    public string[] contentTypes { get; set; }
    public string declaredType { get; set; }
    public int statusCode { get; set; }
}
