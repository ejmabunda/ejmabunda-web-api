namespace ejmabunda_web_api.Models;

public enum NqfLevel
{
    /// <summary>Grade 9 / GETC / ABET Level 4.</summary>
    Grade9 = 1,

    /// <summary>Grade 10 / National Certificate (Vocational) Level 2.</summary>
    Grade10 = 2,

    /// <summary>Grade 11 / National Certificate (Vocational) Level 3.</summary>
    Grade11 = 3,

    /// <summary>Grade 12 (National Senior Certificate / Matric) / National Certificate (Vocational) Level 4.</summary>
    Grade12 = 4,

    /// <summary>Higher Certificate.</summary>
    HigherCertificate = 5,

    /// <summary>Diploma / Advanced Certificate.</summary>
    Diploma = 6,

    /// <summary>Bachelor's Degree / Advanced Diploma / Bachelor of Technology.</summary>
    BachelorsDegree = 7,

    /// <summary>Honours Degree / Postgraduate Diploma / Bachelor of Technology Honours.</summary>
    HonoursDegree = 8,

    /// <summary>Master's Degree.</summary>
    MastersDegree = 9,

    /// <summary>Doctoral Degree.</summary>
    DoctoralDegree = 10
}