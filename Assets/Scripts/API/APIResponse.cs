using System.Collections.Generic;

[System.Serializable]
public class APIResult
{
    public List<EnemyDTO> value { get; set; }
    public List<string> formatters { get; set; }
    public List<string> contentTypes { get; set; }
    public string declaredType { get; set; }
    public int statusCode { get; set; }
}
