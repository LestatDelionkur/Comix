using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Comix.ViewModels.Comics
{
    public class ChapterViewModel
    {
        [Display(Name = "Комикс")]
        public string ComicsTitle { get; set; }
        public long ComicsId { get; set; }
        [Display(Name = "Том")]
        public string VolumeTitle { get; set; }
        public long VolumeId { get; set; }
        [Display(Name = "Глава")]
        public string ChapterTitle { get; set; }
        public long ChapterId { get; set; }
        public long ComicsKindId { get; set; }
        [Display(Name = "Тип")]
        public long ComicsKindTitle { get; set; }

    }
}
