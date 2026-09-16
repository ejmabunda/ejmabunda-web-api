using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

public interface IQualificationService
{
    Task<List<Qualification>> GetAllQualificationsAsync();
}