﻿using FairPlaySocial.ClientServices;
using FairPlaySocial.Common.Global;
using FairPlaySocial.Common.Interfaces.Services;
using FairPlaySocial.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FairPlaySocial.Common.Global.Constants;

namespace FairPlaySocial.SharedUI.Pages.User.Posts
{
    [Authorize(Roles = $"{Roles.User}")]
    [Route(MauiBlazorAppPages.UserRolePagesRoutes.CreateMyPost)]
    public partial class CreateMyPost
    {
        [Inject]
        private MyPostClientService? MyPostClientService { get; set; }
        [Inject]
        private IToastService? ToastService { get; set; }
        [Inject]
        private INavigationService? NavigationService { get; set; }
        [Inject]
        private IGeoLocationService? GeoLocationService { get; set; }
        private CreatePostModel createPostModel = new CreatePostModel()
        {
            Photo = new()
        };
        private bool IsBusy { get; set; }

        private async Task OnValidSubmitAsync()
        {
            try
            {
                IsBusy = true;
                await this.MyPostClientService!
                    .CreateMyPostAsync(this.createPostModel, base.CancellationToken);
                await this.ToastService!.ShowSuccessMessageAsync(
                    "Post has been created", base.CancellationToken);
                this.NavigationService!.NavigateToHomeFeed();
            }
            catch (Exception ex)
            {
                await this.ToastService!
                    .ShowErrorMessageAsync(ex.Message, base.CancellationToken);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Task OnPostPhotoSelectedAsync()
        {
            //This should invoke a Content Moderation Service, similar to what FairPlayDating is doing
            return Task.CompletedTask;
        }

        private async Task GetCurrentGeoLocationAsync()
        {
            try
            {
                this.IsBusy = true;
                var currentGeoLocation = await this.GeoLocationService!
                    .GetCurrentPositionAsync();
                if (currentGeoLocation != null) 
                {
                    this.createPostModel.CreatedAtLatitude = currentGeoLocation.Latitude;
                    this.createPostModel.CreatedAtLongitude = currentGeoLocation.Longitude;
                }
            }
            catch (Exception ex)
            {
                await this.ToastService!
                    .ShowErrorMessageAsync(ex.Message, base.CancellationToken);
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
