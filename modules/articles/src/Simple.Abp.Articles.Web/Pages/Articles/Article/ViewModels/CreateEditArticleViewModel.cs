using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Articles.Web.Pages.Articles.Article.ViewModels
{
    public class CreateEditArticleViewModel: CreateUpdateArticleDto
    {
        [HiddenInput]
        [Required]  
        public override Guid? CatalogId { get; set; }

        [HiddenInput]
        [Required]
        [StringLength(TagConsts.MaxNameLength)]
        public override string Tag { get; set; }
    }
}