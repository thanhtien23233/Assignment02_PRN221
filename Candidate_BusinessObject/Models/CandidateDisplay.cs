namespace Candidate_BusinessObjects.Models;

public partial class CandidateDisplay
{
    public string CandidateId { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public string? ProfileShortDescription { get; set; }

    public string? ProfileUrl { get; set; }
    public string PostingDisplay { get; set; }
}
