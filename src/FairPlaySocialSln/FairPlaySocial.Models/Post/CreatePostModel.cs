﻿using FairPlaySocial.CustomValidation.CustomValidationAttributes;
using FairPlaySocial.Models.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairPlaySocial.Models.Post
{
    public class CreatePostModel
    {
        [Required]
        [StringLength(500)]
        [ProhibitHashTags(ErrorMessage = "Text cannot contain HashTags")]
        [ProhibitUrls(ErrorMessage = "Text cannot contain Urls")]
        public string? Text { get; set; }
        [Required]
        [ValidateComplexType]
        public CreatePhotoModel? Photo { get; set; }
    }
}
