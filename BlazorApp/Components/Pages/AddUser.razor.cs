﻿@page "/adduser"
@inject IUserService UserService

<h3>Add New User</h3>
<EditForm Model="user" OnValidSubmit="HandleSubmit">
    <InputText @bind-Value="user.Name" placeholder="Enter Name" />
    <button type="submit">Add User</button>
</EditForm>

@code {
    private CreateUserDto user = new();

    private async Task HandleSubmit()
    {
        await UserService.AddUserAsync(user);
    }
}
