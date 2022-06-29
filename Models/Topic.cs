using System;
using System.Collections.Generic;

#nullable disable

namespace LearningDiary.Models
{
    public partial class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TimeToMaster { get; set; }
        public int? TimeSpend { get; set; }
        public string Source { get; set; }
        public DateTime? StartLearningDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool? InProgress { get; set; }

        public override string ToString()
        {
            string overriding = "";
            overriding += Title;
            overriding += Description;
            overriding += TimeToMaster;
            overriding += TimeSpend;
            overriding += Source;
            overriding += StartLearningDate;
            overriding += CompletionDate;
            overriding += InProgress;

            return overriding;
        }
    }
}
