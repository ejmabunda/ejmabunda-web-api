using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

public interface IQualificationRepository
{
    Task<List<Qualification>> GetAllQualificationsAsync();
}