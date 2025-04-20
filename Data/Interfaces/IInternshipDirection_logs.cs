using InternsTestModels.Models.Data.Internships;

namespace Data.Interfaces
{
    public interface IInternshipDirection_logs
    {
        public Task LogAsync(InternshipDirection_log log);
    }
}
