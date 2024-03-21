using System.Data.Common;

namespace TecNM.Ecommerce.WebAPI.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }

}