using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EbsTisbiBook.WebAppMVC.Models.Library
{
    public partial class Book
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Подзаголовок")]
        public string TitleAdditional { get; set; }

        [Display(Name = "Ответственное лицо")]
        public string Liability { get; set; }

        [Display(Name = "Издательство")]
        public int? PubhouseId { get; set; }

        [Display(Name = "Год издания")]
        public int Pubyear { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Библиографическая запись")]
        public string BibliographicRecord { get; set; }

        [Display(Name = "Тип публикации")]
        public int? PubtypeId { get; set; }

        [Display(Name = "ФГОС")]
        public int? FgosId { get; set; }

        [Display(Name = "Ссылка на скачивание")]
        public string Url { get; set; }

        [Display(Name = "Ссылка на обложку")]
        public string Image { get; set; }

        [Display(Name = "Целевое назначение")]
        public int? SpecialPurposeId { get; set; }

        [Display(Name = "Язык")]
        public int? LanguageId { get; set; }

        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        public virtual Fgos Fgos { get; set; }
        public virtual Language Language { get; set; }
        public virtual Pubhouse Pubhouse { get; set; }
        public virtual Pubtype Pubtype { get; set; }
        public virtual SpecialPurpose SpecialPurpose { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
