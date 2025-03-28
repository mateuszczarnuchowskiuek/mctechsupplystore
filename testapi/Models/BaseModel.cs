namespace testapi.Models;

public class BaseModel
{
    public int id;
    public string name;
    public bool deleted;
    public DateTime created_at;
    public Guid created_by;
    public DateTime? updated_at;
    public Guid updated_by;
}
