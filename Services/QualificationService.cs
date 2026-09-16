using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Services;

public class QualificationService : IQualificationService
{
    private readonly IQualificationRepository _qualificationRepository;

    public QualificationService(IQualificationRepository qualificationRepository)
    {
        _qualificationRepository = qualificationRepository;
    }

    public async Task<List<Qualification>> GetAllQualificationsAsync()
    {
        return await _qualificationRepository.GetAllQualificationsAsync();
    }
}
