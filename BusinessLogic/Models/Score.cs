using System;
using System.Collections.Generic;

namespace BusinessLogic.Models;

public partial class Score
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int LecturerId { get; set; }

    public int? Score1 { get; set; }

    public string? Comment { get; set; }

    public virtual User Lecturer { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
