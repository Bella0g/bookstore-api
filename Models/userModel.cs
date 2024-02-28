using System.ComponentModel.DataAnnotations;
using CartModel;
using Microsoft.AspNetCore.Identity;

namespace UserModel;

public class User:IdentityUser
{
    public User() { }
}