namespace TecNM.Ecommerce.Core.Entities;

public abstract class EntityBase
{
    public int id { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate{ get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdateDate { get; set; }
}


public class Test1 : EntityBase
{
    
}