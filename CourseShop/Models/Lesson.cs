using System.ComponentModel.DataAnnotations;

namespace CourseShop.Models
{
    public class Lesson
    {
        public int Id { get; set; } // Уникальный идентификатор урока

        [Required]
        [Display(Name = "Название")]
        [StringLength(255, ErrorMessage = "Минимальное введеное значени не должно быть меньше 2", MinimumLength = 2)]
        public string? Title { get; set; } // Название урока

        [Required]
        [Display(Name = "Содержимое")]
        [StringLength(255, ErrorMessage = "Минимальное введеное значени не должно быть меньше 2", MinimumLength = 2)]
        public string? Content { get; set; } // Содержимое урока (может быть текст, видео и т.д.)

        [Required]
        [Display(Name = "ID Курса")]
        public int CourseId { get; set; } // Идентификатор курса, к которому принадлежит урок
        public TimeSpan Duration { get; set; } // Длительность урока
        public virtual Course? Course { get; set; }
    }
}
