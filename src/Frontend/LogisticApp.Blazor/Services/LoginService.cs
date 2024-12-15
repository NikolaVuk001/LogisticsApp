using Microsoft.AspNetCore.Components;

namespace LogisticsApp.Blazor.Services;

public class LoginService
{
    private readonly NavigationManager _navigationManager;
    private bool _isLoggedIn;

    public LoginService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        private set
        {
            _isLoggedIn = value;
            OnStateChanged?.Invoke();
        }
    }

    public event Action? OnStateChanged;

    public void ToggleLoginState()
    {
        IsLoggedIn = !IsLoggedIn;
    }

    public void SetLoginState(bool state)
    {
        IsLoggedIn = state;
    }
}