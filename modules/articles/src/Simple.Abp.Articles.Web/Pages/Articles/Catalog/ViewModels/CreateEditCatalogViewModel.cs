using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System;

namespace Simple.Abp.Articles.Web.Pages.Articles.Catalog.ViewModels
{
    public class CreateEditCatalogViewModel: CreateUpdateCatalogDto
    {
        [HiddenInput]
        public override Guid? ParentId { get; set; }
    }
}