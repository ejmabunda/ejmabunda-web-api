namespace ejmabunda_web_api.Exceptions;

/// <summary>
/// Thrown when a request references one or more <see cref="Models.Skill"/> ids
/// that don't exist. Controllers translate this to a 400 Bad Request.
/// </summary>
public class InvalidSkillIdsException : Exception
{
    public InvalidSkillIdsException(string message) : base(message) { }
}
